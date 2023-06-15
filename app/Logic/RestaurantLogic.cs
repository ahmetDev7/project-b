using static ReservationList;
using System.Globalization;

public class RestaurantLogic
{   
    List<Reservation> _reservations = ReservationList._reservations;
    private string RestaurantName { get; set; }
    public List<ISeatable> Seats { get; set; } = new()
    {   
        // five four-person Seats.
        new DineTable(1, 4),  
        new DineTable(2, 4),
        new DineTable(3, 4),
        new DineTable(4, 4),
        new DineTable(5, 4),

        // eight two-person Seats.
        new DineTable(6, 2),  
        new DineTable(7, 2),  
        new DineTable(8, 2),
        new DineTable(9, 2),
        new DineTable(10, 2),
        new DineTable(11, 2),
        new DineTable(12, 2),
        new DineTable(13, 2),

        // two six-person DineSeats.
        new DineTable(14, 6),
        new DineTable(15, 6),

        // Eigh one-person BarSeats.
        new BarSeat(16),
        new BarSeat(17),
        new BarSeat(18),
        new BarSeat(19),
        new BarSeat(20),
        new BarSeat(21),
        new BarSeat(22),
        new BarSeat(23)
    };

    public RestaurantLogic(string restaurantName) => RestaurantName = restaurantName;

    public DateTime DisplayReservationOverview()
    {   
        bool validDate = false;
        DateTime selectedDate = DateTime.MinValue;
        
        while (!validDate)
        {
            Console.Write("Enter the day you want to see (MM/dd/yyyy): ");
            string inputDate = Console.ReadLine();
            
            if (!DateTime.TryParseExact(inputDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in MM/dd/yyyy format.\n");
                continue;
            }
            validDate = true;
        }
        
        // Filter reservations for the selected date
        var SelectedDateReservations = _reservations.Where(r => r.Time.Date == selectedDate.Date);

        // Display the layout of the restaurant's Seats.
        Console.WriteLine($"{RestaurantName}'s reservations for {selectedDate.ToString("MM/dd/yyyy")}:");
        Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+------------+");
        Console.WriteLine("|    Seat #     |  Reserved By Name    |  Amount Of People |  Time arriving |  Res. Code |   Status   |");
        Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+------------+");
        foreach (var Seat in Seats)
        {
            // Check if the reservation is for the current table
            var reservation = SelectedDateReservations.FirstOrDefault(r => r.TableNumber == Seat.TableNumber);
            if (reservation != null)
            {
                string reservationName = reservation.FirstName ?? "-";
                string reservationTime = reservation.Time.ToString("HH:mm");
                string reservationAmount = reservation.NumberOfPeople.ToString();
                string reservationnumber = reservation.ReservationCode.ToString();

                Console.WriteLine($"| {Seat.TableNumber,-13} | {reservationName,-20} | {reservationAmount,-17} | {reservationTime,-14} |    {reservationnumber,-8}| Occupied   |");
                Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+------------+");
            }
            else
            {
                string reservationName = Seat.Reservation != null ? Seat.Reservation.FirstName : "-";
                string reservationTime = Seat.Reservation != null ? Seat.Reservation.Time.ToString("HH:mm") : "-";
                string reservationAmount = Seat.Reservation != null ? Seat.Reservation.NumberOfPeople.ToString() : "-";

                Console.WriteLine($"| {Seat.TableNumber,-13} | {reservationName,-20} | {reservationAmount,-17} | {reservationTime,-14} |    ----    | {(Seat.Available ? "Available " : "Occupied")} |");
                Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+------------+");
            }
        }

        // Display the legend for the status of the Seats.
        Console.WriteLine();
        Console.WriteLine("Legend:");
        Console.WriteLine("  - Available: Seat is unoccupied and available for seating.");
        Console.WriteLine("  - Occupied: Seat is currently occupied by guests.");
        Console.WriteLine("  - Out of Order: Seat is currently unavailable due to maintenance or other issues.");

        return selectedDate;
    }
    
    public void PrintTableMap(DateTime date)
    {
        Console.Clear();
        var SelectedDateReservations = _reservations.Where(r => r.Time.Date == date);

        Console.WriteLine($"{RestaurantName}'s reservations for {date.ToString("MM/dd/yyyy")}:");
        Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                                        Dining Area                                       │");
        Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────┘");

        // Iterate through the list of seats
        for (int i = 0; i < Seats.Count; i++)
        {
            ISeatable seat = Seats[i];

            // Check if the seat is not a BarSeat, print it in the dining area
            if (seat.GetType() != typeof(BarSeat))
            {
                // Check if the table number is present in the reservations JSON file
                bool isTableReserved = SelectedDateReservations.Any(r => r.TableNumber == seat.TableNumber);

                // Print the table number and capacity
                Console.Write($"  ");

                // Print the seats based on the capacity
                for (int j = 0; j < seat.Capacity; j++)
                {
                    Console.Write(" ");

                    if (isTableReserved)
                    {
                        var reservation = SelectedDateReservations.FirstOrDefault(r => r.TableNumber == seat.TableNumber);

                        if (reservation != null && reservation.NumberOfPeople > j)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("☒");
                        }
                        else
                        {
                            Console.Write("☐");
                        }
                    }
                    else
                    {
                        if (j < seat.Capacity)
                        {
                            Console.Write("☐");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    Console.ResetColor();
                }

                Console.WriteLine("");
                Console.WriteLine("  _______________ ");
                Console.WriteLine($" │   Table {seat.TableNumber.ToString().PadLeft(2)}    │  ");
                Console.WriteLine(" └───────────────┘ \n");
            }
        }

        // Get the list of bar seats and print them
        var BarSeats = Seats.Where(s => s.GetType() == typeof(BarSeat)).ToList();
        if (BarSeats.Any())
        {
            Console.Write("  ");
            for (int i = 0; i < BarSeats.Count; i++)
            {
                ISeatable seat = BarSeats[i];

                // Check if the table number is present in the reservations JSON file
                bool isTableReserved = SelectedDateReservations.Any(r => r.TableNumber == seat.TableNumber);

                for (int j = 0; j < seat.Capacity; j++)
                {
                    Console.Write(" ");

                    if (isTableReserved)
                    {
                        var reservation = SelectedDateReservations.FirstOrDefault(r => r.TableNumber == seat.TableNumber);

                        if (reservation != null && reservation.NumberOfPeople > j)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{seat.TableNumber.ToString().PadLeft(2)}☒");
                        }
                        else
                        {
                            Console.Write($"{seat.TableNumber.ToString().PadLeft(2)}☐");
                        }
                    }
                    else
                    {
                        if (j < seat.Capacity)
                        {
                            Console.Write($"{seat.TableNumber.ToString().PadLeft(2)}☐");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    Console.ResetColor();
                }

                Console.Write("    ");
            }

            Console.WriteLine("");
            Console.WriteLine("  ________________________________________________________________  ");
            Console.WriteLine($" │                              BAR                               │   ");
            Console.WriteLine(" └────────────────────────────────────────────────────────────────┘ \n");
        }
    }
}
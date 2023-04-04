public class Restaurant
{   
    private string RestaurantName { get; set; }
    public List<ISeatable> Seats { get; set; } = new List<ISeatable>()
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
        new BarSeat(16, 1),
        new BarSeat(17, 1),
        new BarSeat(18, 1),
        new BarSeat(19, 1),
        new BarSeat(20, 1),
        new BarSeat(21, 1),
        new BarSeat(22, 1),
        new BarSeat(23, 1)
    };

    public Restaurant(string restaurantName) => RestaurantName = restaurantName;

    public void DisplayRestaurantSeats()
    {
        Console.WriteLine("Welcome to " + RestaurantName + "!\n");

        List<List<int>> seatLayout = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3, 4, 5 },
            new List<int>() { 6, 7, 8, 9, 10 },
            new List<int>() { 11, 12, 13, 14, 15 },
            new List<int>() { 16, 17, 18, 20, 21 },
            new List<int>() { 22, 23}
        };

        // Loop through each row of the seat layout.
        for (int i = 0; i < seatLayout.Count; i++)
        {
            Console.Write("|");  // Start the row with a vertical line.

            // Loop through each seat in the row.
            for (int j = 0; j < seatLayout[i].Count; j++)
            {
                int SeatNumber = seatLayout[i][j];
                ISeatable? Seat = Seats.Find(t => ((t as DineTable)?.TableNumber == SeatNumber) || (t as BarSeat)?.TableNumber == SeatNumber);

                // If the seat is empty, display a blank space.
                if (Seat == null)
                {
                    Console.Write("    ");
                }
                else
                {
                    // If the seat is reserved, display the reservation holder's name.
                    if (!Seat.Available)
                    {
                        Console.Write($" {Seat.Reservation!.FirstName.Substring(0, 1)} ");
                    }
                    // Otherwise, display the appropriate number of empty boxes to represent the seats.
                    else
                    {   
                        string seatBox = "☐"; // Unicode box character
                    
                        Console.Write($" {(Seat is DineTable ? "DineTable" : "BarSeat")}: {Seat.TableNumber.ToString().PadLeft(2)} Seats: ");
                        for (int k = 0; k < Seat.Capacity; k++)
                        {
                            Console.Write(seatBox);
                        }
                        Console.Write(" ");
                    }
                }
                Console.Write("|");  // End the seat with a vertical line.
            }
            Console.WriteLine();  // Move to the next line.
        }
        Console.WriteLine();
    }

    public void DisplayReservationOverview()
    {
        Console.WriteLine($"Map of {RestaurantName}:");
        Console.WriteLine();

        // Display the layout of the restaurant's Seats.
        Console.WriteLine("Layout:");
        Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+");
        Console.WriteLine("|    Seat #    |  Reserved By Name    |  Amount Of People |  Time arriving |   Status   |");
        Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+");
        foreach (var Seat in Seats)
        {   
            string reservationName = Seat.Reservation != null ? Seat.Reservation.FirstName : "-";
            string reservationTime = Seat.Reservation != null ? Seat.Reservation.Time.ToString("HH:mm") : "-";
            string reservationAmount = Seat.Reservation != null ? Seat.Reservation.NumberOfPeople.ToString() : "-";

            Console.WriteLine($"| {Seat.TableNumber,-13} | {reservationName,-20} | {reservationAmount,-17} | {reservationTime,-14} | {(Seat.Available ? "Available" : "Occupied"),-10} |");
            Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+");
        }

        // Display the legend for the status of the Seats.
        Console.WriteLine();
        Console.WriteLine("Legend:");
        Console.WriteLine("  - Available: Seat is unoccupied and available for seating.");
        Console.WriteLine("  - Occupied: Seat is currently occupied by guests.");
        Console.WriteLine("  - Out of Order: Seat is currently unavailable due to maintenance or other issues.");
    }

}
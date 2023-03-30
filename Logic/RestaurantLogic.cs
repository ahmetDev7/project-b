
public class Restaurant
{   
    private string RestaurantName { get; set; }
    public List<Table> tables { get; set; } = new()
    {   
        // five four-person tables.
        new Table(1, 4),  
        new Table(2, 4),
        new Table(3, 4),
        new Table(4, 4),
        new Table(5, 4),

        // eight two-person tables.
        new Table(6, 2),  
        new Table(7, 2),  
        new Table(8, 2),
        new Table(9, 2),
        new Table(10, 2),
        new Table(11, 2),
        new Table(12, 2),
        new Table(13, 2),

        // two six-person tables.
        new Table(14, 6),
        new Table(15, 6)
    };
    public Restaurant(string restaurantName) => RestaurantName = restaurantName;

    // In case they expand, this overloaded constructor is meant for the new restaurants.
    public Restaurant(string restaurantName, List<Table> newTables) : this(restaurantName) => tables = newTables;

    public void DisplayRestaurantSeats()
    {
        Console.WriteLine("Welcome to " + RestaurantName + "!\n");

        // Define the layout of the restaurant and its seats.
        int[,] seatLayout = new int[,]
        {
            {  1,  2,  3,  4,  5 },
            {  6,  7,  8,  9, 10 },
            { 11, 12, 13, 14, 15 }
        };

        // Loop through each row of the seat layout.
        for (int i = 0; i < seatLayout.GetLength(0); i++)
        {
            Console.Write("|");  // Start the row with a vertical line.

            // Loop through each seat in the row.
            for (int j = 0; j < seatLayout.GetLength(1); j++)
            {
                int tableNumber = seatLayout[i, j];
                Table? table = tables.Find(t => t.TableNumber == tableNumber);

                // If the seat is empty, display a blank space.
                if (table == null)
                {
                    Console.Write("    ");
                }
                else
                {
                    // If the seat is reserved, display the reservation holder's name.
                    if (!table.Available)
                    {
                        Console.Write($" {table.Reservation!.FirstName.Substring(0, 1)} ");
                    }
                    // Otherwise, display the appropriate number of empty boxes to represent the seats.
                    else
                    {
                        string seatBox = "☐"; // Unicode box character
                        Console.Write($" Table: {table.TableNumber.ToString().PadLeft(2)} Seats: ");
                        for (int k = 0; k < table.Capacity; k++)
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

        // Display the layout of the restaurant's tables.
        Console.WriteLine("Layout:");
        Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+");
        Console.WriteLine("|    Table #    |  Reserved By Name    |  Amount Of People |  Time arriving |   Status   |");
        Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+");
        foreach (var table in tables)
        {   
            string reservationName = table.Reservation != null ? table.Reservation.FirstName : "-";
            string reservationTime = table.Reservation != null ? table.Reservation.Time.ToString("HH:mm") : "-";
            string reservationAmount = table.Reservation != null ? table.Reservation.NumberOfPeople.ToString() : "-";

            Console.WriteLine($"| {table.TableNumber,-13} | {reservationName,-20} | {reservationAmount,-17} | {reservationTime,-14} | {(table.Available ? "Available" : "Occupied"),-10} |");
            Console.WriteLine("+---------------+----------------------+-------------------+----------------+------------+");
        }

        // Display the legend for the status of the tables.
        Console.WriteLine();
        Console.WriteLine("Legend:");
        Console.WriteLine("  - Available: Table is unoccupied and available for seating.");
        Console.WriteLine("  - Occupied: Table is currently occupied by guests.");
        Console.WriteLine("  - Out of Order: Table is currently unavailable due to maintenance or other issues.");
    }

}
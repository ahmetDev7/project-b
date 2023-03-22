public static class NavigationMenu
{
    public static void ReservationMenu(List<Table> tables)
    {
        // Ask for which table they want to go for.

        Console.Write("Enter the table number you want to reserve: ");
        int tableNumber = int.Parse(Console.ReadLine()!);

        // Find the table in the list with the matching table number.
        Table? table = tables.Find(t => t.TableNumber == tableNumber);

        if (table != null)
        {
            // Prompt the user for reservation details.
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Enter the amount of people: ");
            int amountOfPeople = int.Parse(Console.ReadLine()!);
            Console.Write("Enter the reservation time (HH:mm): ");
            DateTime time = DateTime.Parse(Console.ReadLine()!);

            // Make the reservation for the selected table.
            table.ReserveTable(firstName!, lastName!, amountOfPeople, time);
            Console.WriteLine();
            Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
        }
        else
        {
            Console.WriteLine("Table not found.");
        }
    }
}

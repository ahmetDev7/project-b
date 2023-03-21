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
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter the amount of people: ");
            int amount = int.Parse(Console.ReadLine()!);
            Console.Write("Enter the reservation time (HH:mm): ");
            DateTime time = DateTime.Parse(Console.ReadLine()!);

            // Make the reservation for the selected table.
            table.ReserveTable(name!, amount, time);

            Console.WriteLine("Table " + table.TableNumber + " reserved for " + name + " at " + time.ToString("HH:mm"));
        }
        else
        {
            Console.WriteLine("Table not found.");
        }
    }
}

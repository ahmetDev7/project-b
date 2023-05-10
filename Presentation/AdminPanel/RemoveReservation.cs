using System.Collections.Generic;
using static ReservationList;

public class RemoveReservation
{
    Restaurant restaurant = new("Restaurant");

    public void RemoveReservationMenu()
    {

        int selectedTable;

        while (true)
        {
            Console.Clear();
            restaurant.DisplayReservationOverview();
            Console.WriteLine("Enter a table number to delete: ");
            string userDeleteInput = Console.ReadLine();
            selectedTable = int.Parse(userDeleteInput);
            ReservationList.DeleteReservationByTableNumber(selectedTable);
            restaurant.DisplayReservationOverview();
            Console.WriteLine("Removed from reservations..");
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            Console.Clear();
            break;
        }
    }
}

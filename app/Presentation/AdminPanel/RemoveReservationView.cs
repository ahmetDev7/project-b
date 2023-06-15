using System.Collections.Generic;
using static ReservationList;
using System;

public class RemoveReservationView
{
    RestaurantLogic restaurant = new("Restaurant");

    public void RemoveReservationMenu()
    {   
        DateTime date = DateTime.MinValue;
        while (true)
        {
            date = restaurant.DisplayReservationOverview();
            System.Console.WriteLine("\n(1) Remove reservation by number\n(2) Remove all reservations");
            System.Console.Write("Enter your option: ");
            int userOption = int.Parse(Console.ReadLine()!);
            if (userOption == 1)
            {
                RemoveReservationByNumber(date);
                break;
            }
            else if (userOption == 2)
            {
                ReservationList.DeleteAllReservations(date);
                System.Console.WriteLine("\nSuccessfully deleted all reservations.\n");
                break;
            }
        }
        System.Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();
    }
    public void RemoveReservationByNumber(DateTime date)
    {   
        Console.Write("Enter a table number to delete: ");
        string userDeleteInput = Console.ReadLine();
        int selectedTable = int.Parse(userDeleteInput);
        ReservationList.DeleteReservationByTableNumber(selectedTable, date);
        Console.WriteLine($"\nSuccessfully deleted table number {selectedTable} from the reservations.");
    }
}

using System.Collections.Generic;
using static ReservationList;
using System;

public class RemoveReservationView
{
    RestaurantLogic restaurant = new("Restaurant");

    public void RemoveReservationMenu()
    {
        while (true)
        {
            restaurant.DisplayReservationOverview();
            System.Console.WriteLine("(1) Remove reservation by number\n(2) Remove all reservations");
            System.Console.Write("Enter your option: ");
            int userOption = int.Parse(Console.ReadLine()!);
            if (userOption == 1)
            {
                RemoveReservationByNumber();
                break;
            }
            else if (userOption == 2)
            {
                ReservationList.DeleteAllReservations();
                System.Console.WriteLine("\nSuccessfully deleted all reservations.\n");
                break;
            }
        }
        Console.Clear();
    }
    public void RemoveReservationByNumber()
    {   
        Console.WriteLine("Enter a table number to delete: ");
        string userDeleteInput = Console.ReadLine();
        int selectedTable = int.Parse(userDeleteInput);
        ReservationList.DeleteReservationByTableNumber(selectedTable);
        restaurant.DisplayReservationOverview();
        Console.WriteLine("Removed from reservations..");

    }
}

using System.Collections.Generic;
public class RestaurantInfoAdmin
{
    public void RestaurantInfoAdminMenu()
    {
        RestaurantInfoLogic restaurantInfoLogic = new();

        restaurantInfoLogic.AddOpeningHours("Monday", "10pm-9am");
        restaurantInfoLogic.AddOpeningHours("Tuesday", "10pm-9am");
        restaurantInfoLogic.AddOpeningHours("Wednesday", "10pm-9am");
        restaurantInfoLogic.AddOpeningHours("Thursday", "10pm-9am");
        restaurantInfoLogic.AddOpeningHours("Friday", "10pm-9am");
        restaurantInfoLogic.AddOpeningHours("Saturday", "10pm-9am");
        restaurantInfoLogic.AddOpeningHours("Sunday", "10pm-9am");
        
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Change Information of the Restaurant");
        Console.WriteLine("------------------------------------------------------");
        /*        Console.WriteLine($"1) Current Restaurant name: {restaurantInfoLogic.GetRestaurantName()}");
                Console.WriteLine("");
                Console.WriteLine($"2) Current Restaurant description: {restaurantInfoLogic.GetRestaurantDescription()}");
                Console.WriteLine("");
                Console.WriteLine("Current Opening Hours");
                Console.WriteLine("3) Monday: " + restaurantInfoLogic.GetOpeningHourPerDay("Monday"));
                Console.WriteLine("4) Tuesday: " + restaurantInfoLogic.GetOpeningHourPerDay("Tuesday"));
                Console.WriteLine("5) Wednesday: " + restaurantInfoLogic.GetOpeningHourPerDay("Wednesday"));
                Console.WriteLine("6) Thursday: " + restaurantInfoLogic.GetOpeningHourPerDay("Thursday"));
                Console.WriteLine("7) Friday: " + restaurantInfoLogic.GetOpeningHourPerDay("Friday"));
                Console.WriteLine("8) Saturday " + restaurantInfoLogic.GetOpeningHourPerDay("Saturday"));
                Console.WriteLine("9) Sunday: " + restaurantInfoLogic.GetOpeningHourPerDay("Sunday"));
                Console.WriteLine("------------------------------------------------------");*/

        while (true)
        {
            var restaurantInfo = restaurantInfoLogic.LoadRestaurantInfo();
            Console.WriteLine($"3) Monday: {restaurantInfo[0].OpeningHours["Monday"]}");
            Console.WriteLine("Enter an option from the menu (from 1-9): ");
            string userInput = Console.ReadLine();
            string selectedDay = "";
            switch (userInput)
                {
                case "1":
                    Console.Write("Enter new restaurant name: ");
                    string updatedRestaurantName = Console.ReadLine();
                    restaurantInfo[0].RestaurantName = updatedRestaurantName;
                    Console.WriteLine("Restaurant name updated!");
                    break;
                case "2":
                    break;
                case "3":
                    restaurantInfo[0].OpeningHours["Monday"] = "10uur-1uur";
                    break;
                case "4":
                    selectedDay = "Thursday";
                    break;
                case "5":
                    selectedDay = "Friday";
                    break;
                case "6":
                    selectedDay = "Saturday";
                    break;
                case "7":
                    selectedDay = "Sunday";
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
                }
                restaurantInfoLogic.editRestaurantInfo(restaurantInfo);
        }
    }
}

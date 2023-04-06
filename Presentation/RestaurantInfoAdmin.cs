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
            Console.WriteLine("Change Opening Hours of the Restaurant");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Current Opening Hours");
            Console.WriteLine("1) Monday: " + restaurantInfoLogic.GetOpeningHourPerDay("Monday"));
            Console.WriteLine("2) Tuesday: " + restaurantInfoLogic.GetOpeningHourPerDay("Tuesday"));
            Console.WriteLine("3) Wednesday: " + restaurantInfoLogic.GetOpeningHourPerDay("Wednesday"));
            Console.WriteLine("4) Thursday: " + restaurantInfoLogic.GetOpeningHourPerDay("Thursday"));
            Console.WriteLine("5) Friday: " + restaurantInfoLogic.GetOpeningHourPerDay("Friday"));
            Console.WriteLine("6) Saturday " + restaurantInfoLogic.GetOpeningHourPerDay("Saturday"));
            Console.WriteLine("7) Sunday: " + restaurantInfoLogic.GetOpeningHourPerDay("Sunday"));
            Console.WriteLine("------------------------------------------------------");
        }
}

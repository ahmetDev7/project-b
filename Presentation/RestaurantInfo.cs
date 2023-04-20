public class RestaurantInfo
{
    public void RestaurantInfoMenu()
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
        Console.WriteLine("Welcome to " + restaurantInfoLogic.GetRestaurantName());
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine(restaurantInfoLogic.GetRestaurantDescription());
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Monday: " + restaurantInfoLogic.GetOpeningHourPerDay("Monday"));
        Console.WriteLine("Tuesday: " + restaurantInfoLogic.GetOpeningHourPerDay("Tuesday"));
        Console.WriteLine("Wednesday: " + restaurantInfoLogic.GetOpeningHourPerDay("Wednesday"));
        Console.WriteLine("Thursday: " + restaurantInfoLogic.GetOpeningHourPerDay("Thursday"));
        Console.WriteLine("Friday: " + restaurantInfoLogic.GetOpeningHourPerDay("Friday"));
        Console.WriteLine("Saturday " + restaurantInfoLogic.GetOpeningHourPerDay("Saturday"));
        Console.WriteLine("Sunday: " + restaurantInfoLogic.GetOpeningHourPerDay("Sunday"));
        Console.WriteLine("------------------------------------------------------");
        Console.ReadKey();
    }
}
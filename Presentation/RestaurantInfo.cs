public class RestaurantInfo
{
    public void RestaurantInfoMenu()
    {
        RestaurantInfoLogic restaurantInfoLogic = new();
        var restaurantInfo = restaurantInfoLogic.LoadRestaurantInfo();

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"Welcome to: {restaurantInfo[0].RestaurantName}");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"{restaurantInfo[0].Description}");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"Monday: {restaurantInfo[0].OpeningHours["Monday"]}");
        Console.WriteLine($"Tuesday: {restaurantInfo[0].OpeningHours["Tuesday"]}");
        Console.WriteLine($"Wednesday: {restaurantInfo[0].OpeningHours["Wednesday"]}");
        Console.WriteLine($"Thursday: {restaurantInfo[0].OpeningHours["Thursday"]}");
        Console.WriteLine($"Friday: {restaurantInfo[0].OpeningHours["Friday"]}");
        Console.WriteLine($"Saturday: {restaurantInfo[0].OpeningHours["Saturday"]}");
        Console.WriteLine($"Sunday: {restaurantInfo[0].OpeningHours["Sunday"]}");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Press enter to return back to home.");
        Console.ReadKey();
    }
}
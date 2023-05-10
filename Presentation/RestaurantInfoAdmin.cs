using System.Collections.Generic;

public class RestaurantInfoAdmin
{
    public void RestaurantInfoAdminMenu()
    {
        RestaurantInfoLogic restaurantInfoLogic = new();

        // restaurantInfoLogic.AddOpeningHours("Monday", "10pm-9am");
        // restaurantInfoLogic.AddOpeningHours("Tuesday", "10pm-9am");
        // restaurantInfoLogic.AddOpeningHours("Wednesday", "10pm-9am");
        // restaurantInfoLogic.AddOpeningHours("Thursday", "10pm-9am");
        // restaurantInfoLogic.AddOpeningHours("Friday", "10pm-9am");
        // restaurantInfoLogic.AddOpeningHours("Saturday", "10pm-9am");
        // restaurantInfoLogic.AddOpeningHours("Sunday", "10pm-9am");

        while (true)
        {
            Console.Clear();
            var restaurantInfo = restaurantInfoLogic.LoadRestaurantInfo();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Change Information of the Restaurant");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"1) Current Restaurant name: {restaurantInfo[0].RestaurantName}");
            Console.WriteLine("");
            Console.WriteLine($"2) Current Restaurant description: {restaurantInfo[0].Description}");
            Console.WriteLine("");
            Console.WriteLine("Current Opening Hours");
            Console.WriteLine($"3) Monday: {restaurantInfo[0].OpeningHours["Monday"]}");
            Console.WriteLine($"4) Tuesday: {restaurantInfo[0].OpeningHours["Tuesday"]}");
            Console.WriteLine($"5) Wednesday: {restaurantInfo[0].OpeningHours["Wednesday"]}");
            Console.WriteLine($"6) Thursday: {restaurantInfo[0].OpeningHours["Thursday"]}");
            Console.WriteLine($"7) Friday: {restaurantInfo[0].OpeningHours["Friday"]}");
            Console.WriteLine($"8) Saturday: {restaurantInfo[0].OpeningHours["Saturday"]}");
            Console.WriteLine($"9) Sunday: {restaurantInfo[0].OpeningHours["Sunday"]}");
            Console.WriteLine("10) Return to homepage");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Enter an option from the menu (from 1-9): ");
            string userInput = Console.ReadLine();
            string updatedOpeningTime;
            switch (userInput)
            {
                case "1":
                    Console.Write("Enter new restaurant name: ");
                    string updatedRestaurantName = Console.ReadLine();
                    restaurantInfo[0].RestaurantName = updatedRestaurantName;
                    Console.WriteLine("Restaurant name updated!");
                    break;
                case "2":
                    Console.Write("Enter new restaurant description: ");
                    string updatedRestaurantDescription = Console.ReadLine();
                    restaurantInfo[0].Description = updatedRestaurantDescription;
                    Console.WriteLine("Restaurant description updated!");
                    break;
                case "3":
                    Console.Write("Enter new time for Monday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Monday"] = updatedOpeningTime;
                    break;
                case "4":
                    Console.Write("Enter new time for Tuesday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Tuesday"] = updatedOpeningTime;
                    break;
                case "5":
                    Console.Write("Enter new time for Wednesday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Wednesday"] = updatedOpeningTime;
                    break;
                case "6":
                    Console.Write("Enter new time for Thursday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Thursday"] = updatedOpeningTime;
                    break;
                case "7":
                    Console.Write("Enter new time for Friday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Friday"] = updatedOpeningTime;
                    break;
                case "8":
                    Console.Write("Enter new time for Saturday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Saturday"] = updatedOpeningTime;
                    break;
                case "9":
                    Console.Write("Enter new time for Sunday: ");
                    updatedOpeningTime = Console.ReadLine();
                    restaurantInfo[0].OpeningHours["Sunday"] = updatedOpeningTime;
                    break;
                case "10":
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            restaurantInfoLogic.editRestaurantInfo(restaurantInfo);
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

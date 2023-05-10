using System;
using System.Text;
using static RemoveReservation;

public static class NavigationMenu
{
    public static void Menu()
    {
        Restaurant restaurant = new("Restaurant");
        RestaurantInfo restaurantInfo = new();
        RestaurantInfoAdmin adminRestaurantInfo = new();

        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
        (int left, int top) = Console.GetCursorPosition();
        int selectedOption = 1;
        bool isMenuOpen = true;
        var decorator = $"\u001b[38;2;196;102;217m>  ";
        Console.Clear();
        while (isMenuOpen)
        {

            Console.SetCursorPosition(left, top);
            Console.WriteLine("What would you like to do?\n");

            Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Reserve table\u001b[0m");
            Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Log in\u001b[0m");
            Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Restaurant Information\u001b[0m");
            Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Show Menu\u001b[0m");
            Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Show Map\u001b[0m");
            Console.WriteLine($"{(selectedOption == 6 ? decorator : "   ")}(ADMIN) View reservations\u001b[0m");
            Console.WriteLine($"{(selectedOption == 7 ? decorator : "   ")}(ADMIN) Remove a reservation\u001b[0m");
            Console.WriteLine($"{(selectedOption == 8 ? decorator : "   ")}(ADMIN) Change Restaurant info & opening hours\u001b[0m");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 < 1) ? 8 : selectedOption - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1 > 8) ? 1 : selectedOption + 1;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    isMenuOpen = HandleMenuOption(selectedOption, restaurant, restaurantInfo, adminRestaurantInfo);
                    break;
            }
        }
    }

        public static bool HandleMenuOption(int option, Restaurant restaurant, RestaurantInfo restaurantInfo, RestaurantInfoAdmin adminRestaurantInfo)
        {
            RemoveReservation removeReservation = new RemoveReservation();

            switch (option)
            {
                case 1:
                    ReservationMenu();
                    break;
                case 2:
                    LoginMenu();
                    break;
                case 3:
                    restaurantInfo.RestaurantInfoMenu();
                    break;
                case 4:
                    FilterMenu.FilterOptions();
                    break;
                case 5:
                    restaurant.PrintTableMap();
                    break;
                case 6:
                    restaurant.DisplayReservationOverview();
                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 7:
                    removeReservation.RemoveReservationMenu();
                    break;
                case 8:
                    adminRestaurantInfo.RestaurantInfoAdminMenu();
                    break;
            }

            return true;
            Console.Clear();
        }
        public static void ReservationMenu()
    {
        // Ask for which table they want to go for.
        Restaurant JacksRestaurant = new Restaurant("Jacks restaurant");
        List<ISeatable> tables = JacksRestaurant.Seats;
        JacksRestaurant.DisplayRestaurantSeats();
        Console.Write("Enter the table number you want to reserve: ");
        int tableNumber = int.Parse(Console.ReadLine()!);

        // Find the table in the list with the matching table number.
        ISeatable? table = tables.Find(t => t.TableNumber == tableNumber);

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
            table.ReserveTable(firstName!, lastName!, amountOfPeople, time, tableNumber);
            Console.WriteLine();
            Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
        }
        else
        {
            Console.WriteLine("Table not found.");
        }
        Console.Clear();
    }

    public static void LoginMenu()
    {
        System.Console.WriteLine("Select an option:");
        System.Console.WriteLine("(1) Log in");
        System.Console.WriteLine("(2) Create a new account");
        int UserInput = int.Parse(Console.ReadLine()!);
        switch (UserInput)
        {
            case 1:
                Login();
                break;
            case 2:
                MakeNewAccount();
                break;
            default:
                System.Console.WriteLine("Invalid input");
                break;
        }
        Console.Clear();
    }
    public static User Login()
    {
        User? CurrentUser = null;
        do
        {
            System.Console.Write("Enter your username: ");
            string userName = Console.ReadLine()!;
            System.Console.Write("Enter your password");
            string password = Console.ReadLine()!;
            System.Console.Write("Enter your email: ");
            string mail = Console.ReadLine()!;
            CurrentUser = AccountManager.users.FirstOrDefault(user => user.UserName == userName && user.PassWord == password && user.Mail == mail);
            if (CurrentUser == null)
            {
                Console.WriteLine("Invalid username or password, please try again.");
            }
        } while (CurrentUser != null);
        return CurrentUser!;
        Console.Clear();
    }
    public static void MakeNewAccount()
    {
        System.Console.Write("Enter an username: ");
        string userName = Console.ReadLine()!;
        System.Console.Write("Enter a password: ");
        string passWord = Console.ReadLine()!;
        System.Console.Write("Enter your email: ");
        string mail = Console.ReadLine()!;
        AccountManager.AddUser(new User(userName, passWord, mail));
        Console.Clear();
    }
}

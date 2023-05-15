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
        var decorator = $"\u001B[34m>  ";
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
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    FilterMenu.FilterOptions();
                    break;
                case 5:
                    restaurant.PrintTableMap();
                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 6:
                    restaurant.DisplayReservationOverview();
                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 7:
                    removeReservation.RemoveReservationMenu();
                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 8:
                    adminRestaurantInfo.RestaurantInfoAdminMenu();
                    Console.Clear();
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
        JacksRestaurant.PrintTableMap();
        int tableNumber;

        while (true)
        {
            Console.Write("Enter the table number you want to reserve: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: Please enter a valid table number.");
                continue;
            }

            if (!int.TryParse(input, out tableNumber))
            {
                Console.WriteLine("Error: Please enter a valid table number.");
                continue;
            }

            if (tableNumber >= tables.Count || tableNumber < 0)
            {
                Console.WriteLine($"Table number {tableNumber} does not exist.");
                continue;
            }

            break;
        }

        // Find the table in the list with the matching table number.
        ISeatable table = tables[tableNumber];

        // Prompt the user for reservation details.
        // Asks for the time of reservation.
        Console.Write("Enter the reservation time (HH:mm): ");
    string inputTime = Console.ReadLine();
    DateTime time = DateTime.Parse(inputTime);

        // Asks for the first name.
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        if (string.IsNullOrEmpty(firstName))
        {
            Console.WriteLine("Error: Please enter a valid first name.");
            return;
        }

        // Asks for the last name.
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        if (string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine("Error: Please enter a valid last name.");
            return;
        }

        // Asks for the amount of people.
        Console.Write("Enter the number of people: ");
        int amountOfPeople;

        while (true)
        {
            amountOfPeople = int.Parse(Console.ReadLine());

            if (amountOfPeople <= 0)
            {
                Console.WriteLine("Error: Number of people must be greater than zero.");
                continue;
            }

            if (amountOfPeople <= table.Capacity)
            {
                // Make the reservation for the selected table.
                table.ReserveTable(firstName, lastName, amountOfPeople, time, tableNumber);
                Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
                System.Console.WriteLine();
                System.Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine($"Error: The selected table has a capacity of {table.Capacity} people. Please enter a valid number of people.");
                Console.WriteLine("You have two options:");
                Console.WriteLine("(1) Choose another table");
                Console.WriteLine("(2) Combine tables");

                int choice;

                while (true)
                {
                    Console.Write("Enter your choice: ");
                    string inputChoice = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputChoice) || !int.TryParse(inputChoice, out choice))
                    {
                        Console.WriteLine("Error: Please enter a valid choice.");
                        continue;
                    }

                    if (choice != 1 && choice != 2)
                    {
                        Console.WriteLine("Error: Invalid choice. Please enter either 1 or 2.");
                        continue;
                    }

                    break;
                }

                if (choice == 1)
                {
                    // Choose another table
                    Console.Write("Enter the new table number you want to reserve: ");
                    int newTableNumber;

                    while (true)
                    {
                        string inputNewTable = Console.ReadLine();

                        if (string.IsNullOrEmpty(inputNewTable) || !int.TryParse(inputNewTable, out newTableNumber))
                        {
                            Console.WriteLine("Error: Please enter a valid table number.");
                            continue;
                        }

                        if (newTableNumber >= tables.Count || newTableNumber < 0)
                        {
                            Console.WriteLine($"Table number {newTableNumber} does not exist.");
                            continue;
                        }

                        break;
                    }

                    // Find the new table in the list
                    ISeatable newTable = tables[newTableNumber];

                    if (amountOfPeople <= newTable.Capacity)
                    {
                        // Make the reservation for the new table
                        newTable.ReserveTable(firstName, lastName, amountOfPeople, time, newTableNumber);
                        Console.WriteLine($"Table {newTable.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Error: The selected table has a capacity of {newTable.Capacity} people. Please enter a valid amount of people.");
                        continue;
                    }
                }
                else if (choice == 2)
                {
                    // Combine tables
                    Console.Write("Enter the additional table number: ");
                    int additionalTableNumber;

                    while (true)
                    {
                        string inputAdditionalTable = Console.ReadLine();

                        if (string.IsNullOrEmpty(inputAdditionalTable) || !int.TryParse(inputAdditionalTable, out additionalTableNumber))
                        {
                            Console.WriteLine("Error: Please enter a valid table number.");
                            continue;
                        }

                        if (additionalTableNumber >= tables.Count || additionalTableNumber < 0)
                        {
                            Console.WriteLine($"Table number {additionalTableNumber} does not exist.");
                            continue;
                        }

                        break;
                    }

                    // Find the additional table in the list
                    ISeatable additionalTable = tables[additionalTableNumber];

                    int totalCapacity = table.Capacity + additionalTable.Capacity;
                    
                    if (amountOfPeople <= totalCapacity)
                    {
                        // Make the reservation for the combined tables
                        table.ReserveTable(firstName, lastName, amountOfPeople, time, tableNumber);
                        additionalTable.ReserveTable(firstName, lastName, amountOfPeople, time, additionalTableNumber);
                        Console.WriteLine($"Tables {table.TableNumber} and {additionalTable.TableNumber} are reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Error: The combined tables have a capacity of {totalCapacity} people. Please enter a valid amount of people.");
                        continue;
                    }
                };
            }
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

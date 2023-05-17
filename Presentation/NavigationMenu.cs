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
            Console.WriteLine("Welcome to our restaurant reservation page!\nSelect one of the following options.\n");

            Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Reserve table\u001b[0m");
            Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Log in\u001b[0m");
            Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Create an account\u001b[0m");
            Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Show Menu\u001b[0m");
            Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Show Map\u001b[0m");
            Console.WriteLine($"{(selectedOption == 6 ? decorator : "   ")}(ADMIN) View reservations\u001b[0m");
            Console.WriteLine($"{(selectedOption == 7 ? decorator : "   ")}(ADMIN) Remove a reservation\u001b[0m");
            Console.WriteLine($"{(selectedOption == 8 ? decorator : "   ")}(ADMIN) Change Restaurant info & opening hours\u001b[0m");
            Console.WriteLine($"{(selectedOption == 9 ? decorator : "   ")}Restaurant information\u001b[0m");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption - 1 < 1) ? 9 : selectedOption - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1 > 9) ? 1 : selectedOption + 1;
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
                    MakeNewAccount();
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
                case 9:
                    restaurantInfo.RestaurantInfoMenu();
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
                Console.WriteLine("Error: Please enter a valid table number.\n");
                continue;
            }
            else if (!int.TryParse(input, out tableNumber))
            {
                Console.WriteLine("Error: Please enter a valid table number.\n");
                continue;
            }
            else if (tableNumber >= tables.Count || tableNumber < 0)
            {
                Console.WriteLine($"Table number {tableNumber} does not exist.\n");
                continue;
            }

            bool tableAvailable = !ReservationList._reservations.Any(reservation => reservation.TableNumber == tableNumber);

            if (!tableAvailable)
            {
                Console.WriteLine($"Table number {tableNumber} is not available.\nPlease choose another table.\n");
                continue;
            }
            break;
        }


        // Find the table in the list with the matching table number.
        ISeatable table = tables[tableNumber - 1];

        // Asks for the time of reservation.
        bool validTime = false;
        DateTime time = DateTime.MinValue;

        while (!validTime)
        {
            Console.Write("Enter the reservation time (HH:mm): ");
            string inputTime = Console.ReadLine();

            try
            {
                time = DateTime.Parse(inputTime);
                validTime = true; // Set validTime to true if parsing succeeds
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time format. Please enter the time in HH:mm format.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                System.Console.WriteLine();
            }
        }

        // Asks for the first name.
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        if (string.IsNullOrEmpty(firstName))
        {
            Console.WriteLine("Error: Please enter a valid first name.\n");
            return;
        }

        // Asks for the last name.
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        if (string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine("Error: Please enter a valid last name.\n");
            return;
        }

        // Asks for the amount of people.
        int amountOfPeople;
        while (true)
        {   
            Console.Write("Enter the number of people: ");
            while (!int.TryParse(Console.ReadLine(), out amountOfPeople))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.\n");
                Console.Write("Enter the number of people: ");
            }
            if (amountOfPeople <= 0)
            {
                Console.WriteLine("Error: Number of people must be greater than zero.\n");
                continue;
            }

            if (amountOfPeople <= table.Capacity)
            {
                // Make the reservation for the selected table.
                table.ReserveTable(firstName, lastName, amountOfPeople, time, tableNumber);
                Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}\n");
                System.Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine($"Error: The selected table number {tableNumber} has a capacity of {table.Capacity} people.\n");
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
                        Console.WriteLine("Error: Please enter a valid choice.\n");
                        continue;
                    }

                    if (choice != 1 && choice != 2)
                    {
                        Console.WriteLine("Error: Invalid choice. Please enter either 1 or 2.\n");
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
                            Console.WriteLine("Error: Please enter a valid table number.\n");
                            continue;
                        }

                        if (newTableNumber >= tables.Count || newTableNumber < 0)
                        {
                            Console.WriteLine($"Table number {newTableNumber} does not exist.\n");
                            continue;
                        }

                        break;
                    }

                    // Find the new table in the list
                    ISeatable newTable = tables[newTableNumber - 1];

                    if (amountOfPeople <= newTable.Capacity)
                    {
                        // Make the reservation for the new table
                        newTable.ReserveTable(firstName, lastName, amountOfPeople, time, newTableNumber);
                        Console.WriteLine($"Table {newTable.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}\n");
                        System.Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Error: The selected table number {newTableNumber} has a capacity of {newTable.Capacity} people. Please enter a valid amount of people.\n");
                        continue;
                    }
                }
                if (choice == 2)
                {
                    // Combine tables
                    List<int> additionalTableNumbers = new List<int>();
                    int totalCapacity = table.Capacity;

                    while (amountOfPeople > totalCapacity)
                    {
                        Console.Write("Enter the additional table number: ");
                        string inputAdditionalTable = Console.ReadLine();

                        if (!int.TryParse(inputAdditionalTable, out int additionalTableNumber))
                        {
                            Console.WriteLine("Error: Please enter a valid table number.\n");
                            continue;
                        }

                        if (additionalTableNumbers.Contains(additionalTableNumber))
                        {
                            Console.WriteLine($"Table number {additionalTableNumber} is already selected. Please choose a different table.\n");
                            continue;
                        }

                        if (ReservationList._reservations.Any(reservation => reservation.TableNumber == additionalTableNumber))
                        {   
                            System.Console.WriteLine($"Table number {additionalTableNumber} is already reserved. Please choose a different table.\n");
                            continue;
                        }
    
                        ISeatable additionalTable = tables[additionalTableNumber];

                        totalCapacity += additionalTable.Capacity;
                        additionalTableNumbers.Add(additionalTableNumber);

                        if (amountOfPeople > totalCapacity)
                        {   
                            System.Console.Write($"\nTable number {tableNumber}");
                            for (int i = 0; i < additionalTableNumbers.Count(); i++)
                            {
                                System.Console.Write($" and {additionalTableNumbers[i]}");
                            }
                            System.Console.WriteLine($" totals the capacity of {totalCapacity} people, do not reach the desired amount of {amountOfPeople} people.");
                            System.Console.WriteLine($"You have {amountOfPeople - totalCapacity} more {(amountOfPeople - totalCapacity == 1 ? "person" : "people")}!");
                            System.Console.WriteLine("Choose another table.\n");
                        }
                    }
                    // Make the reservation for the combined tables
                    table.ReserveTable(firstName, lastName, amountOfPeople, time, tableNumber);
                    Console.Write($"\nTables {table.TableNumber}");

                    foreach (int additionalTableNumber in additionalTableNumbers)
                    {
                        ISeatable additionalTable = tables[additionalTableNumber - 1];
                        additionalTable.ReserveTable(firstName, lastName, amountOfPeople, time, additionalTableNumber);
                        Console.Write($" and {additionalTableNumber}");
                    }

                    Console.WriteLine($" are reserved for {firstName} {lastName} at {time.ToString("HH:mm")}\n");
                    System.Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                }
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
        System.Console.WriteLine($"Congrats {userName}! You successfully created your account!");
        System.Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}

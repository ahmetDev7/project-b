using System;
using System.Text;
using static RemoveReservation;

public static class NavigationMenu
{
    private static Restaurant restaurant = new Restaurant("Restaurant");
    private static RestaurantInfo restaurantInfo = new RestaurantInfo();
    private static RestaurantInfoAdmin adminRestaurantInfo = new RestaurantInfoAdmin();
    private static RemoveReservation removeReservation = new RemoveReservation();
    private static UserRoleManager roleManager = new UserRoleManager();
    public static void Menu()
    {
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

            if (!roleManager.IsLoggedIn)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to Jake's Restaurant!\nYou are currently not logged in.\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Log in\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Create an account\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Reserve table\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Show Menu\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Show Map\u001b[0m");
                Console.WriteLine($"{(selectedOption == 6 ? decorator : "   ")}Restaurant information\u001b[0m");
            }
            else if (roleManager.IsLoggedIn && roleManager.CurrentUserRole == "user")
            {
                Console.Clear();
                Console.WriteLine($"Customer, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Reserve table\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Show Menu\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Show Map\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Restaurant information\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Log Out\u001b[0m");
            }
            else if (roleManager.IsLoggedIn && roleManager.CurrentUserRole == "employee")
            {
                Console.Clear();
                Console.WriteLine($"Employee, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}View reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Remove a reservation\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Log Out\u001b[0m");
            }
            else if (roleManager.IsLoggedIn && roleManager.CurrentUserRole == "admin")
            {
                Console.Clear();
                Console.WriteLine($"Admin, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}View reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Remove a reservation\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Change Restaurant info & opening hours\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Log Out\u001b[0m");
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (!roleManager.IsLoggedIn)
                    {
                        selectedOption = (selectedOption - 1 < 1) ? 6 : selectedOption - 1;
                    }
                    else
                    {
                        switch (roleManager.CurrentUserRole)
                        {
                            case "user":
                                selectedOption = (selectedOption - 1 < 1) ? 5 : selectedOption - 1;
                                break;
                            case "employee":
                                selectedOption = (selectedOption - 1 < 1) ? 3 : selectedOption - 1;
                                break;
                            case "admin":
                                selectedOption = (selectedOption - 1 < 1) ? 4 : selectedOption - 1;
                                break;
                        }
                    }
                    break;
                
                case ConsoleKey.DownArrow:
                    if (!roleManager.IsLoggedIn)
                    {
                        selectedOption = (selectedOption + 1 > 6) ? 1 : selectedOption + 1;
                    }
                    else
                    {
                        switch (roleManager.CurrentUserRole)
                        {
                            case "user":
                                selectedOption = (selectedOption + 1 > 5) ? 1 : selectedOption + 1;
                                break;
                            case "employee":
                                selectedOption = (selectedOption + 1 > 3) ? 1 : selectedOption + 1;
                                break;
                            case "admin":
                                selectedOption = (selectedOption + 1 > 4) ? 1 : selectedOption + 1;
                                break;
                        }
                    }
                    break;
                
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (!roleManager.IsLoggedIn)
                    {
                        if (selectedOption == 1)
                        {
                            Login();
                        }
                        else if (selectedOption == 2)
                        {
                            MakeNewAccount();
                        }
                        else if (selectedOption == 3)
                        {
                            ReservationMenu();
                        }
                        else if (selectedOption == 4)
                        {
                            FilterMenu.FilterOptions();
                        }
                        else if (selectedOption == 5)
                        {
                            restaurant.PrintTableMap();
                        }
                        else if (selectedOption == 6)
                        {
                            Console.Clear();
                            restaurantInfo.RestaurantInfoMenu();
                        }
                    }
                    else if (roleManager.IsLoggedIn)
                    {
                        if (roleManager.CurrentUserRole == "user")
                        {
                            if (selectedOption == 1)
                            {
                                ReservationMenu();
                            }
                            else if (selectedOption == 2)
                            {
                                FilterMenu.FilterOptions();
                            }
                            else if (selectedOption == 3)
                            {
                                restaurant.PrintTableMap();
                            }
                            else if (selectedOption == 4)
                            {
                                Console.Clear();
                                restaurantInfo.RestaurantInfoMenu();
                            }
                            else if (selectedOption == 5)
                            {
                                roleManager.Logout();
                            }
                        }
                        else if (roleManager.CurrentUserRole == "employee")
                        {
                            if (selectedOption == 1)
                            {
                                restaurant.DisplayReservationOverview();
                            }
                            else if (selectedOption == 2)
                            {
                                removeReservation.RemoveReservationMenu();
                            }
                            else if (selectedOption == 3)
                            {
                                roleManager.Logout();
                            }
                        }
                        else if (roleManager.CurrentUserRole == "admin")
                        {
                            if (selectedOption == 1)
                            {
                                restaurant.DisplayReservationOverview();
                            }
                            else if (selectedOption == 2)
                            {
                                removeReservation.RemoveReservationMenu();
                            }
                            else if (selectedOption == 3)
                            {
                                adminRestaurantInfo.RestaurantInfoAdminMenu();
                            }
                            else if (selectedOption == 4)
                            {
                                roleManager.Logout();
                            }
                        }
                    }
                    break;
            }
        }
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
                Console.WriteLine($"This is your reservation code: {table.Reservation.ReservationCode}");
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

    public static void Login()
    {
        User? foundAccount = null;
        while(true){   
            System.Console.Write("Enter your username: ");
            string userName = Console.ReadLine()!;
            System.Console.Write("Enter your password: ");
            string password = Console.ReadLine()!;
            foundAccount = AccountManager.users.FirstOrDefault(user => user.UserName == userName && user.PassWord == password);
            if (foundAccount == null)
            {
                Console.WriteLine("Invalid username or password, please try again.");
            } else{
                roleManager.Login(foundAccount.Role);
                break;
            }
        }
        Console.Clear();
    }
    public static void MakeNewAccount()
    {
        System.Console.Write("Enter your email: ");
        string mail = Console.ReadLine()!;
        System.Console.Write("Enter an username: ");
        string userName = Console.ReadLine()!;
        System.Console.Write("Enter a password: ");
        string passWord = Console.ReadLine()!;
        AccountManager.AddUser(new User(userName, passWord, mail, "user"));
        System.Console.WriteLine($"Congrats {userName}! You successfully created your account!");
        System.Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}

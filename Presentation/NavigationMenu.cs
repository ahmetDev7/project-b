public static class NavigationMenu
{
    public static void Menu()
    {
        Restaurant restaurant = new("Restaurant");
        RestaurantInfo restaurantInfo = new();
        RestaurantInfoAdmin adminRestaurantInfo = new();

        while (true)
        {
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("1: Reserve table");
            System.Console.WriteLine("2: Log in");
            System.Console.WriteLine("3: View reservations");
            System.Console.WriteLine("4: Restaurant Information");
            System.Console.WriteLine("5: Change opening hours");
            System.Console.WriteLine("6: Show Menu");
            int UserInput = int.Parse(Console.ReadLine()!);
            switch (UserInput)
            {
                case 1:
                    ReservationMenu();
                    break;
                case 2:
                    LoginMenu();
                    break;
                case 3:
                    restaurant.DisplayReservationOverview();
                    break;
                case 4:
                    restaurantInfo.RestaurantInfoMenu();
                    break;
                case 5:
                    adminRestaurantInfo.RestaurantInfoAdminMenu();
                    break;
                case 6:
                    FilterMenu.Filter();
                    break;
                default:
                    break;
            }
        }
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
        int amountOfPeople;
        if (table != null && table is DineTable)
        {   
            // Prompt the user for reservation details.
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Enter the reservation time (HH:mm): ");
            DateTime time = DateTime.Parse(Console.ReadLine()!);
            while (true) {
                Console.Write("Enter the amount of people: ");
                amountOfPeople = int.Parse(Console.ReadLine()!);
                if (amountOfPeople > table!.Capacity) {
                    System.Console.WriteLine($"Table number {table.TableNumber} does not fit {amountOfPeople} people.");
                    System.Console.WriteLine("1: Choose another table\n2: Combine tables to fit the desired reservation amount:");
                    int option = int.Parse(Console.ReadLine()!);
                    switch (option)
                    {
                        case 1:
                            JacksRestaurant.DisplayRestaurantSeats();
                            Console.Write("Enter the table number you want to reserve instead: ");
                            int newTableNumber = int.Parse(Console.ReadLine()!);
                            table = tables.Find(t => t.TableNumber == newTableNumber);
                            if (table == null) {
                                Console.WriteLine($"Table number {newTableNumber} does not exist.");
                                continue;
                            } else if (amountOfPeople > table.Capacity) {
                                Console.WriteLine($"Table number {newTableNumber} does not fit {amountOfPeople} people. Please try again.");
                                continue;
                            } else {
                                table.ReserveTable(firstName!, lastName!, amountOfPeople, time, table.TableNumber);
                                Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
                                break;
                            }
                        case 2:
                            // Selection menu for the additional table.
                            JacksRestaurant.DisplayRestaurantSeats();
                            Console.Write("Enter the additional table number you want to add to the reservation: ");

                            // Creation of the new table object. 
                            newTableNumber = int.Parse(Console.ReadLine()!);
                            ISeatable? newTable = tables.Find(t => t.TableNumber == newTableNumber);

                            // The reservation for the initial table
                            table.ReserveTable(firstName!, lastName!, amountOfPeople, time, table.TableNumber);

                            // The reservation for the additional table
                            newTable!.ReserveTable(firstName!, lastName!, amountOfPeople - table.Capacity, time, newTableNumber);

                            // Prompt the user the succession message for reservation.
                            System.Console.WriteLine($"Tables {table.TableNumber} and {newTable.TableNumber} are reserved for {firstName} {lastName} with {amountOfPeople} people at {time.ToString("HH:mm")}");
                            System.Console.WriteLine($"Where table {table.TableNumber} is reserved for {amountOfPeople} and table {newTable.TableNumber} for {amountOfPeople - table.Capacity} people");
                            break;
                        default:
                            System.Console.WriteLine("Not a valid option. Please try again.");
                            continue;
                    } break;
                } else {
                    table.ReserveTable(firstName!, lastName!, amountOfPeople, time, table.TableNumber);
                    Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} with {amountOfPeople} people at {time.ToString("HH:mm")}");
                    break;
                }
            }

        }
        else if (table != null && table is BarSeat)
        {
            // Prompt the user for reservation details.
            Console.Write("Enter your first name: ");
            string? firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string? lastName = Console.ReadLine();
            Console.Write("Enter the reservation time (HH:mm): ");
            DateTime time = DateTime.Parse(Console.ReadLine()!);

            // Make the reservation for the selected table.
            table.ReserveTable(firstName!, lastName!, 1, time, table.TableNumber);
            Console.WriteLine();
            Console.WriteLine($"{(table is DineTable ? "DineTable" : "BarSeat")} {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}");
        }
        else
        {
            Console.WriteLine("Table not found.");
        }
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
    }
}

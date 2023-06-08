public class ReservationMenuView
{
    List<ISeatable> tables = Ultilities.restaurant.Seats;

    public void loginOrRegisterObligation(){
        Console.WriteLine("To finish your reservation you need to login in or create an account first.");
        Console.WriteLine("(1) Login");
        Console.WriteLine("(2) Register");
        Console.Write("Select an option:");

        string userChoice = Console.ReadLine();

        switch(userChoice){
            case "1":
                Ultilities.login.viewLogin();
                break;
            case "2":
                System.Console.Write("Enter your email: ");
                string mail = Console.ReadLine()!;
                System.Console.Write("Enter an username: ");
                string userName = Console.ReadLine()!;
                System.Console.Write("Enter a password: ");
                string passWord = Console.ReadLine()!;
                AccountManager.AddUser(new User(userName, passWord, mail, "user", AccountManager.users.Last().UserId + 1));
                break;
        }
    }

   public void ViewReservationMenu()
    {
        // Ask for which table they want to go for.
        Ultilities.restaurant.PrintTableMap();
        int tableNumber;
        int ReservationCode = Reservation.GenerateReservationCode();

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
                if(!Ultilities.roleManager.IsLoggedIn){
                    loginOrRegisterObligation();
                };
                // Make the reservation for the selected table.
                table.ReserveTable(firstName, lastName, amountOfPeople, time, tableNumber, ReservationCode, Ultilities.roleManager.UserId);
                Console.WriteLine($"Table {table.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}\n");
                Console.WriteLine($"This is your reservation code: {ReservationCode}");
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
                        if(!Ultilities.roleManager.IsLoggedIn){
                            loginOrRegisterObligation();
                        };
                        // Make the reservation for the new table
                        newTable.ReserveTable(firstName, lastName, amountOfPeople, time, newTableNumber, ReservationCode, Ultilities.roleManager.UserId);
                        Console.WriteLine($"Table {newTable.TableNumber} is reserved for {firstName} {lastName} at {time.ToString("HH:mm")}\n");
                        Console.WriteLine($"This is your reservation code: {ReservationCode}");
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
                    if(!Ultilities.roleManager.IsLoggedIn){
                        loginOrRegisterObligation();
                    };
                    table.ReserveTable(firstName, lastName, amountOfPeople, time, tableNumber,ReservationCode,Ultilities.roleManager.UserId);
                    Console.Write($"\nTables {table.TableNumber}");

                    foreach (int additionalTableNumber in additionalTableNumbers)
                    {
                        ISeatable additionalTable = tables[additionalTableNumber - 1];
                        additionalTable.ReserveTable(firstName, lastName, amountOfPeople, time, additionalTableNumber,ReservationCode,Ultilities.roleManager.UserId);
                        Console.Write($" and {additionalTableNumber}");
                    }

                    Console.WriteLine($" are reserved for {firstName} {lastName} at {time.ToString("HH:mm")}\n");
                    Console.WriteLine($"This is your reservation code: {ReservationCode}");
                    System.Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                }
            }
        }
        Console.Clear();
    }
}
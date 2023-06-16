public class FutureMenu
{
    // Show the future menu
    public static void ShowMenu()
    {
        Console.Clear();
        DishesDataAccessMonth.ShowFutureMenu();
        Console.ReadLine();
    }

    // Add a dish to the future menu
    public static void AddDish()
{
    Console.WriteLine("Enter dish details (or ENTER 0 to go back):");

    Console.Write("Title: ");
    string title = Console.ReadLine();

    if (title == "0")
    {
        Console.Clear();
        return; // Go back to the previous menu
    }

    Console.Write("Ingredients: ");
    string ingredients = Console.ReadLine();

    Console.Write("Category: ");
    string category = Console.ReadLine();

    Console.Write("Description: ");
    string description = Console.ReadLine();

    Console.Write("Price: ");
    string price = Console.ReadLine();

    Console.Write("Country: ");
    string country = Console.ReadLine();

    Console.Write("Month: ");
    string month = Console.ReadLine();

    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(ingredients) || string.IsNullOrEmpty(category)
        || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(country)
        || string.IsNullOrEmpty(month))
    {
        Console.WriteLine("Invalid input. Please provide values for all fields.");
        Console.WriteLine("Press enter to continue....");
        Console.ReadKey();
        Console.Clear();
        return;
    }

    DishesDataAccessMonth.AddDishToFutureMenu(title, ingredients, category, description, price, country, month);
    Console.WriteLine($"{title} has been added to the menu");
    Console.WriteLine("Press enter to continue....");
    Console.ReadKey();
    Console.Clear();
}

    // Edit a dish on the future menu
    public static void EditDish()
{
    if (DishesDataAccessMonth.ShowDishTitles())
    {
        Console.Write("Enter the line number of the dish you want to edit (Enter 0 to go back): ");
        if (int.TryParse(Console.ReadLine(), out int line))
        {
            if (line == 0)
            {
                // Go back or perform any action you want
                return;
            }

            Console.WriteLine("Enter updated dish details:");

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Ingredients: ");
            string ingredients = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Price: ");
            string price = Console.ReadLine();

            Console.Write("Country: ");
            string country = Console.ReadLine();

            Console.Write("Month: ");
            string month = Console.ReadLine();

            DishesDataAccessMonth.EditDishOnFutureMenu(line, title, ingredients, category, description, price, country, month);
        }
        else
        {
            Console.WriteLine("Invalid line number. Please enter a valid line number.");
        }
    }
    else
    {
        // Handle the case when the menu is not available or empty
        // Go back or perform any action you want
        Console.WriteLine("Press ENTER to continue....");
        Console.ReadKey();
        Console.Clear();
    }
}
    public static void ClearMonthMenu()
    {
        DishesDataAccessMonth.DeleteMenuFile();
        Console.WriteLine("Press ENTER to continue....");
        Console.ReadKey();
        Console.Clear();

    }

public void FutureMenuOptions()
{
    bool validChoice = false;

    while (!validChoice)
    {
        Console.WriteLine("\n--- Next Month Menu Options ---");
        Console.WriteLine("1. Show Next Month Menu");
        Console.WriteLine("2. Add Dish to Next Month Menu");
        Console.WriteLine("3. Edit Dish on Next Month Menu");
        Console.WriteLine("4. Clear the Next Month Menu");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                FutureMenu.ShowMenu();
                Console.Clear();
                break;
            case "2":
                Console.Clear();
                FutureMenu.AddDish();
                break;
            case "3":
                Console.Clear();
                FutureMenu.EditDish();
                break;
            case "4":
                Console.Clear();
                FutureMenu.ClearMonthMenu();
                break;
            case "5":
                validChoice = true;
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                break;
        }
    }
}
}







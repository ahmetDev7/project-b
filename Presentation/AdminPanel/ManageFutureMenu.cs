public class FutureMenu
{
    // Show the future menu
    public static void ShowMenu()
    {
        DishesDataAccessMonth.ShowFutureMenu();
        Console.ReadLine();
    }

    // Add a dish to the future menu
    public static void AddDish()
    {
        Console.WriteLine("Enter dish details:");

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

        DishesDataAccessMonth.AddDishToFutureMenu(title, ingredients, category, description, price, country, month);
    }

    // Edit a dish on the future menu
    public static void EditDish()
    {
        DishesDataAccessMonth.ShowDishTitles();
        Console.Write("Enter the line number of the dish you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int line))
        {
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
    public static void ClearMonthMenu()
    {
        DishesDataAccessMonth.DeleteMenuFile();
        Console.WriteLine("The next months menu has been removed");
    }

public void FutureMenuOptions()
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
            break;
        case "2":
            FutureMenu.AddDish();
            break;
        case "3":
            FutureMenu.EditDish();
            break;
        case "4":
            FutureMenu.ClearMonthMenu();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
            break;
    }
}
}







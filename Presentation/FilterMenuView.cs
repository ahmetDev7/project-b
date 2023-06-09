using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FilterMenuView
{
    public static string csvfile = "DataSources/Dishes.csv";
    public static string CurrentMenu = "Current";
    public static List<Dish> dishes = CsvToClass(csvfile);
    public static void FilterOptions(string filter = "all")
    {

        SetUpConsole();
        // Initialize variables
        bool isSelected = false;
        var option = 1;

        var decorator = $"\u001B[34m>  ";
        ConsoleKeyInfo key;
        (int left, int top) = Console.GetCursorPosition();

        // Loop until user selects an option
        while (!isSelected)
        {
            // Display menu options
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{(option == 1 ? decorator : "   ")}All\u001b[0m");
            Console.WriteLine($"{(option == 2 ? decorator : "   ")}Categories\u001b[0m");
            Console.WriteLine($"{(option == 3 ? decorator : "   ")}Ingredient\u001b[0m");
            Console.WriteLine($"{(option == 4 ? decorator : "   ")}Country of Origin\u001b[0m");
            Console.WriteLine($"{(option == 5 ? decorator : "   ")}Search Ingredient\u001b[0m");
            int i = 6;
            if (CurrentMenu != "Current")
            {
                Console.WriteLine($"{(option == i ? decorator : "   ")}Current Menu\u001b[0m");
                i++;
            }
            if (CurrentMenu != "Future")
            {
                Console.WriteLine($"{(option == i ? decorator : "   ")}Future Menu\u001b[0m");
                i++;
            }
            if (CurrentMenu != "Wine")
            {
                Console.WriteLine($"{(option == i ? decorator : "   ")}Wine Menu\u001b[0m");
                i++;
            }

            Console.WriteLine($"{(option == 8 ? decorator : "   ")}Back\u001b[0m");

            // Get user input
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    option = option == 1 ? 8 : option - 1;
                    break;
                case ConsoleKey.DownArrow:
                    option = option == 8 ? 1 : option + 1;
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        // Handle user selection

        if (option == 1)
        {
            FilterMenuView.SortList("all", "all");
        }
        else if (option == 2)

        {
            FilterMenuView.FilterCategory("catagory");
        }
        else if (option == 3)
        {
            FilterMenuView.FilterCategory("ingredient");
        }
        else if (option == 4)
        {
            FilterMenuView.FilterCategory("country");
        }
        else if (option == 5)
        {
            FilterMenuView.SearchIngredient();
        }
        else if (option == 6 && CurrentMenu != "Current")
        {
            CurrentMenu = "Current";
            dishes = CsvToClass("DataSources/Dishes.csv");
            FilterMenuView.FilterOptions();
        }
        else if (option == 7 && CurrentMenu != "Future" || option == 6 && CurrentMenu != "Future")
        {
            CurrentMenu = "Future";
            dishes = CsvToClass("DataSources/FutureMenu.csv");
            FilterMenuView.FilterOptions();
        }
        else if (option == 7 && CurrentMenu != "Wine")
        {
            CurrentMenu = "Wine";
            dishes = CsvToClass("DataSources/Wine.csv");
            FilterMenuView.FilterOptions();
        }
        else if (option == 8)
        {
            NavigationMenuView.Menu();
        }
    }
    public static void SearchIngredient()
    {
        Console.WriteLine("Enter Ingredient:");

        // Create a string variable and get user input from the keyboard and store it in the variable
        string ingredient = Console.ReadLine();
        SortList("ingredient", ingredient);

    }
    public static List<Dish> CsvToClass(string csvfile)
    {
        // Read the CSV file
        var lines = File.ReadAllLines(csvfile);

        // Parse the CSV data into Dish objects
        int i = 1;
        var dishes = lines
            .Skip(1)
            .Select(line =>
            {
                var parts = line.Split(';');
                return new Dish
                {
                    ID = i++,
                    Title = parts[0],
                    Ingredients = parts[1].Split(','),
                    Category = parts[2],
                    Description = parts[3],
                    Price = double.Parse(parts[4]),
                    Country = parts[5],
                    Month = parts[6]
                };
            })
            .ToList();
        return dishes;
    }
    public static void SetUpConsole()
    {
        // Set up console
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
        Console.ResetColor();
        Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
        // Display instructions
        if (CurrentMenu == "Current")
        {
            Console.WriteLine("\n \u001b[32mCurrent Menu\u001b[0m");
        }
        else if (CurrentMenu == "Future")
        {
            Console.WriteLine("\n \u001b[32mFuture Menu\u001b[0m");
        }
        else if (CurrentMenu == "Wine")
        {
            Console.WriteLine("\n \u001b[32mWine Menu\u001b[0m");
        }

    }



    static List<string> GetUniqueCategories(List<Dish> dishes, string type)
    {
        List<string> categories = dishes.Select(dish => dish.Category).Distinct().ToList();
        if (type == "catagory")
        {
            categories = dishes.Select(dish => dish.Category).Distinct().ToList();
        }
        else if (type == "country")
        {
            categories = dishes.Select(dish => dish.Country).Distinct().ToList();
        }
        else if (type == "ingredient")
        {
            categories = dishes.SelectMany(dish => dish.Ingredients).Distinct().ToList();
        }
        return categories;
    }
    public static void FilterCategory(string type)
    {
        SetUpConsole();
        var decorator = $"\u001B[34m>  ";
        ConsoleKeyInfo key;

        // Initialize variables
        int num = 0;
        var option = 1;
        int page = 0;
        int pageSize = 20;

        (int left, int top) = Console.GetCursorPosition();

        bool isSelected = false;
        List<string> categories = GetUniqueCategories(dishes, type);
        categories.Sort();

        while (!isSelected)
        {
            Console.Clear(); // Clear the console before displaying new categories
            if (type == "ingredient")
            {
                Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate, use ⬅️  and ➡️ for other page and press \u001b[32mEnter/Return\u001b[0m to select:");

            }
            else
            {
                Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
            }
            int i = 0;
            int x = page * pageSize;

            Console.SetCursorPosition(left, top);
            for (int j = x; j < categories.Count && j < x + pageSize; j++)
            {
                string category = categories[j];
                Console.WriteLine($"{(option == i ? decorator : "   ")}{category}\u001b[0m");
                i++;
            }
            num = i;
            Console.WriteLine($"{(option == num ? decorator : "   ")}Back\u001b[0m");

            // Get user input
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    option = option == 0 ? num : option - 1;
                    break;
                case ConsoleKey.DownArrow:
                    option = option == num ? 0 : option + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (page == 0) { page = (categories.Count - 1) / pageSize; }
                    else { page--; }
                    break;
                case ConsoleKey.RightArrow:
                    page = (page + 1) * pageSize >= categories.Count ? 0 : page + 1;
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        Console.Clear();

        if (option == num)
        {
            FilterMenuView.FilterOptions();
        }
        else
        {
            string selectedCategory = categories[(page * pageSize) + option];
            SortList(type, selectedCategory);
        }
    }


    public static void SortList(string type, string sort, string PriceORTitle = "price", bool UpORDown = true)
    {
        var sortedDishes = dishes.ToList();

        if (type == "catagory")
        {
            sortedDishes = dishes.Where(dish => dish.Category.Contains(sort)).ToList();
        }
        else if (type == "country")
        {

            sortedDishes = dishes.Where(dish => dish.Country.Contains(sort)).ToList();
        }
        else if (type == "ingredient")
        {
            sortedDishes = dishes.Where(dish => dish.Ingredients.Contains(sort, StringComparer.OrdinalIgnoreCase)).ToList();
        }
        else if (type == "all")
        {

        }

        if (PriceORTitle == "price")
        {
            if (UpORDown == true)
            {
                sortedDishes = sortedDishes.OrderBy(dish => dish.Price).ToList();
            }
            else if (UpORDown == false)
            {
                sortedDishes = sortedDishes.OrderByDescending(dish => dish.Price).ToList();
            }
        }
        else if (PriceORTitle == "title")
        {
            if (UpORDown == true)
            {
                sortedDishes = sortedDishes.OrderBy(dish => dish.Title).ToList();
            }
            else if (UpORDown == false)
            {
                sortedDishes = sortedDishes.OrderByDescending(dish => dish.Title).ToList();
            }
        }

        BuildMenu(sortedDishes, type, sort, UpORDown);
    }
    public static void BuildMenu(List<Dish> sortedDishes, string type, string sort, bool UpORDown)
    {
        // Print the unique categories to the console

        SetUpConsole();
        var decorator = $"\u001B[34m>  ";
        var Sorting = $"\u001b[32m> ";
        ConsoleKeyInfo key;

        // Initialize variables
        int num = 0;
        var option = 1;

        (int left, int top) = Console.GetCursorPosition();
        // Write the sorted dishes to the terminal
        bool isSelected = false;
        while (!isSelected)
        {
            int i = 2;
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{(option == 0 ? Sorting : "  ")}Sort on price\u001b[0m");
            Console.WriteLine($"{(option == 1 ? Sorting : "  ")}Sort on Title\u001b[0m");

            foreach (var dish in sortedDishes)
            {
                Console.WriteLine($"{(option == i ? decorator : "   ")}{dish.Title} ({dish.Price}$)\u001b[0m");
                i++;
            }
            num = i;
            Console.WriteLine($"{(option == num ? Sorting : "  ")}Back\u001b[0m");

            // Get user input
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    option = option == 0 ? i : option - 1;
                    break;
                case ConsoleKey.DownArrow:
                    option = option == i ? 0 : option + 1;
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        // Handle user selection
        Console.Clear();
        if (option == 0)
        {
            SortList(type, sort, "price", !UpORDown);
        }
        if (option == 1)
        {
            SortList(type, sort, "title", !UpORDown);
        }
        else if (option == num)
        {
            if (type == "all")
            {
                FilterMenuView.FilterOptions();
            }
            else
            {
                FilterMenuView.FilterCategory(type);
            }

        }
        else
        {
            var dish = sortedDishes[option - 2];
            FilterMenuView.BuildDish(dish, type, sort);
        }
    }

    public static void BuildDish(Dish dish, string type, string sort)
    {
        //clears and setstup the console
        SetUpConsole();
        var decorator = $"\u001B[34m>  ";
        var Sorting = $"\u001b[32m> ";
        ConsoleKeyInfo key;

        var option = 1;
        (int left, int top) = Console.GetCursorPosition();
        bool isSelected = false;
        while (!isSelected)
        {

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"  {dish.Title} ({dish.Price}$)");
            Console.WriteLine("   Ingredients: " + string.Join(", ", dish.Ingredients));
            Console.WriteLine("   Category: " + dish.Category);
            Console.WriteLine("   Country: " + dish.Country);
            Console.WriteLine("   Month: " + dish.Month);
            Console.WriteLine("   Description: " + dish.Description);
            Console.WriteLine($"{(option == 1 ? Sorting : "  ")}Back\u001b[0m");
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    isSelected = true;
                    SortList(type, sort);
                    break;
            }
        }
        Console.Clear();
    }
}

public class Dish
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string[] Ingredients { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Country { get; set; }
    public string Month { get; set; }
}

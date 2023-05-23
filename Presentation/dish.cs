using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class FilterMenu
{

    public static List<Dish> dishes = CsvToClass();
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
            Console.WriteLine($"{(option == 2 ? decorator : "   ")}categories\u001b[0m");
            Console.WriteLine($"{(option == 3 ? decorator : "   ")}ingredient\u001b[0m");
            Console.WriteLine($"{(option == 4 ? decorator : "   ")}country\u001b[0m");
            Console.WriteLine($"{(option == 5 ? decorator : "   ")}search ingredient\u001b[0m");
            Console.WriteLine($"{(option == 6 ? decorator : "   ")}Back\u001b[0m");

            // Get user input
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    option = option == 1 ? 6 : option - 1;
                    break;
                case ConsoleKey.DownArrow:
                    option = option == 6 ? 1 : option + 1;
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        // Handle user selection

        if (option == 1)
        {

        }
        else if (option == 2)

        {
            FilterMenu.FilterCatagory("catagory");
        }
        else if (option == 3)
        {
            FilterMenu.FilterCatagory("ingredient");
        }
        else if (option == 4)
        {
            FilterMenu.FilterCatagory("country");
        }
        else if (option == 5)
        {
            FilterMenu.SearchIngredient();
        }
        else if (option == 6)
        {
            NavigationMenu.Menu();
        }
    }
    public static void SearchIngredient()
    {
        Console.WriteLine("Enter Ingredient:");

        // Create a string variable and get user input from the keyboard and store it in the variable
        string ingredient = Console.ReadLine();
        SortList("ingredient", ingredient);

    }
    public static List<Dish> CsvToClass()
    {
        // Read the CSV file
        var lines = File.ReadAllLines("DataSources/Dishes.csv");

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
                    Price = int.Parse(parts[4]),
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

        // Display instructions
        Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");
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

    public static void FilterCatagory(string type)
    {
        SetUpConsole();
        Console.WriteLine("Sorted by price (from lowest to highest):");
        var decorator = $"\u001B[34m>  ";
        ConsoleKeyInfo key;

        // Initialize variables
        int num = 0;
        var option = 1;

        (int left, int top) = Console.GetCursorPosition();
        // Write the sorted dishes to the terminal
        bool isSelected = false;
        List<string> categories = GetUniqueCategories(dishes, type);
        categories.Sort();
        while (!isSelected)
        {
            int i = 0;
            Console.SetCursorPosition(left, top);
            foreach (string category in categories)
            {
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
        Console.Clear();
        if (option == num)
        {
            FilterMenu.FilterOptions();
        }
        else
        {
            string SelectedCatagory = categories[option];
            SortList(type, SelectedCatagory);
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
            sortedDishes = dishes.Where(dish => dish.Ingredients.Contains(sort)).ToList();
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
        Console.WriteLine("Sorted by price (from lowest to highest):");
        var decorator = $"\u001B[34m>  ";
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
            Console.WriteLine($"{(option == 0 ? decorator : "   ")}sort on price\u001b[0m");
            Console.WriteLine($"{(option == 1 ? decorator : "   ")}sort on Title\u001b[0m");

            foreach (var dish in sortedDishes)
            {
                Console.WriteLine($"{(option == i ? decorator : "   ")}{dish.ID} {dish.Title} ({dish.Price}$)\u001b[0m");
                i++;
            }
            num = i;
            Console.WriteLine($"{(option == num ? decorator : "   ")}Back\u001b[0m");

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
            FilterMenu.FilterCatagory(type);
        }
        else
        {
            var dish = sortedDishes[option - 2];
            FilterMenu.BuildDish(dish, type, sort);
        }
    }

    public static void BuildDish(Dish dish, string type, string sort)
    {
        //clears and setstup the console
        SetUpConsole();
        var decorator = $"\u001B[34m>  ";
        ConsoleKeyInfo key;

        var option = 1;
        (int left, int top) = Console.GetCursorPosition();
        bool isSelected = false;
        while (!isSelected)
        {

            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{dish.ID} {dish.Title} ({dish.Price}$)");
            Console.WriteLine("Ingredients: " + string.Join(", ", dish.Ingredients));
            Console.WriteLine("Category: " + dish.Category);
            Console.WriteLine("Description: " + dish.Description);
            Console.WriteLine("Country: " + dish.Country);
            Console.WriteLine("Month: " + dish.Month);
            Console.WriteLine($"{(option == 1 ? decorator : "   ")}Back\u001b[0m");
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
    public int Price { get; set; }
    public string Country { get; set; }
    public string Month { get; set; }
}

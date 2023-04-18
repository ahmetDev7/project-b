using System;
using System.Text;

public static class FilterMenu
{
    public static void FilterOptions(string filter = "all")
    {
        SetUpConsole();

        // Initialize variables
        bool isSelected = false;
        var option = 1;

        var decorator = $"\u001b[38;2;196;102;217m>  ";
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
            Console.WriteLine($"{(option == 5 ? decorator : "   ")}price\u001b[0m");
            Console.WriteLine($"{(option == 6 ? decorator : "   ")}Back\u001b[0m");

            // Get user input
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    option = option == 0 ? 6 : option - 1;
                    break;
                case ConsoleKey.DownArrow:
                    option = option == 6 ? 0 : option + 1;
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        // Handle user selection
        Console.Clear();
        if (option == 1)
        {
            FilterMenu.Build("All");
        }
        else if (option == 2)
        {
            FilterMenu.FilterCatagory();
        }
        else if (option == 3)
        {
            FilterMenu.FilterCatagory("all", 1);
        }
        else if (option == 4)
        {
            FilterMenu.FilterCatagory("all", 5);
        }
        else if (option == 5)
        {
            FilterMenu.FilterCatagory();
        }
        else if (option == 6)
        {

        }
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
    public static void FilterCatagory(string filter = "all", int collom = 2)
    {
        SetUpConsole();

        // Initialize variables
        bool isSelected = false;
        int num = 0;
        var option = 1;

        var decorator = $"\u001b[38;2;196;102;217m>  ";
        ConsoleKeyInfo key;
        (int left, int top) = Console.GetCursorPosition();

        // Get dishes and categories
        string[] lines = DishesDataAccess.GetLines();
        var categories = lines
            .Skip(1) // Skip the first line (header)
            .SelectMany(line => line.Split(';')[collom]
                .Split(',')
                .Select(ingredient => ingredient.Trim().ToLower())
                .Distinct())
            .Distinct();

        // Remove categories with no dishes
        if (filter.ToLower() != "all")
        {
            categories = categories.Where(category =>
                lines.Any(line =>
                    line.Split(';')[collom]
                    .Split(',')
                    .Select(ingredient => ingredient.Trim().ToLower())
                    .Contains(category)
                    && filter.ToLower() == category));
        }

        // Loop until user selects an option
        while (!isSelected)
        {
            // Display menu options
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{(option == 1 ? decorator : "   ")}All\u001b[0m");

            int i = 2;
            foreach (var category in categories)
            {
                Console.WriteLine($"{(option == i ? decorator : "   ")}{category}\u001b[0m");
                i++;
            }

            Console.WriteLine($"{(option == i ? decorator : "   ")}Back\u001b[0m");
            num = i;

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
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        // Handle user selection
        Console.Clear();
        if (option == 1)
        {
            FilterMenu.Build("All");
        }
        else if (option == num)
        {
            FilterMenu.FilterOptions();
        }
        else
        {
            FilterMenu.Build(categories.ElementAt(option - 2), collom);
        }
    }

    public static void Build(string filter = "all", int collom = 2)
    {
        SetUpConsole();

        // Initialize variables
        bool isSelected = false;
        int num = 0;
        var option = 1;

        var decorator = $"\u001b[38;2;196;102;217m>  ";
        ConsoleKeyInfo key;
        (int left, int top) = Console.GetCursorPosition();

        // Get dishes and filter by category
        string[] lines = DishesDataAccess.GetLines();
        var filteredDishes = new string[][] { };

        if (collom == 1)
        {
            filteredDishes = lines
                .Select(line => line.Split(';'))
                .Where(fields => fields[1].Split(',').Contains(filter))
                .ToArray();
        }
        else if (collom == 4)
        {

        }
        else
        {
            filteredDishes = lines
                .Select(line => line.Split(';'))
                .Where(fields => filter.ToLower() == "all" || fields[collom].ToLower() == filter.ToLower())
                .ToArray();
        }
        // Loop until user selects an option
        while (!isSelected)
        {
            // Display menu options
            int i = 0;
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"{(option == i ? decorator : "   ")}Add Dish\u001b[0m");
            foreach (var dish in filteredDishes)
            {
                string Title = dish[0];
                Console.WriteLine($"{(option == i + 1 ? decorator : "   ")}{Title}\u001b[0m");
                i++;
            }
            num = i + 1;
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
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }

        // Handle user selection
        Console.Clear();
        if (option == num)
        {
            FilterMenu.FilterCatagory("all", collom);
        }
        else if (option == 0)
        {
            LogicDishes.Add();
        }
        else
        {
            string[] fields = filteredDishes[option - 1];
            string Title = fields[0];
            string Ingredients = fields[1];
            string Category = fields[2];
            string Discription = fields[3];
            string Price = fields[4];
            string Country = fields[5];
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Ingredients: {Ingredients}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Country: {Country}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Discription: {Discription}");
            (left, top) = Console.GetCursorPosition();
            while (isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{decorator}Back\u001b[0m");
                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        isSelected = false;
                        Build(filter, collom);
                        break;
                }
            }
        }
    }
}

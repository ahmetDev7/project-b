using System;
using System.Text;

public static class FilterMenu
{
    public static void Filter(string filter = "all")
    {
        // Set up console
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
        Console.ResetColor();

        // Display instructions
        Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");

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
            Console.WriteLine($"{(option == 2 ? decorator : "   ")}Meat\u001b[0m");
            Console.WriteLine($"{(option == 3 ? decorator : "   ")}Fish\u001b[0m");
            Console.WriteLine($"{(option == 4 ? decorator : "   ")}Vegan\u001b[0m");
            Console.WriteLine($"{(option == 5 ? decorator : "   ")}Vegaterian\u001b[0m");
            Console.WriteLine($"{(option == 6 ? decorator : "   ")}Drink\u001b[0m");
            Console.WriteLine($"{(option == 7 ? decorator : "   ")}Back\u001b[0m");

            // Get user input
            key = Console.ReadKey(false);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    option = option == 0 ? 7 : option - 1;
                    break;
                case ConsoleKey.DownArrow:
                    option = option == 7 ? 0 : option + 1;
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
            FilterMenu.Build("Meat");
        }
        else if (option == 3)
        {
            FilterMenu.Build("Fish");
        }
        else if (option == 4)
        {
            FilterMenu.Build("Vegan");
        }
        else if (option == 5)
        {
            FilterMenu.Build("Vegaterian");
        }
        else if (option == 6)
        {
            FilterMenu.Build("Drink");
        }
        else if (option == 7)
        {

        }
    }
    public static void Build(string filter = "all")
    {
        // Set up console
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
        Console.ResetColor();

        // Display instructions
        Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");

        // Initialize variables
        bool isSelected = false;
        int num = 0;
        var option = 1;

        var decorator = $"\u001b[38;2;196;102;217m>  ";
        ConsoleKeyInfo key;
        (int left, int top) = Console.GetCursorPosition();

        // Get dishes and filter by category
        string[] lines = DishesDataAccess.GetLines();
        var filteredDishes = lines
            .Where(line => filter.ToLower() == "all" || line.Split(';')[2].ToLower() == filter.ToLower())
            .Select(line => line.Split(';'))
            .ToArray();

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
            FilterMenu.Filter();
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
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Ingredients: {Ingredients}");
            Console.WriteLine($"Category: {Category}");
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
                        Build(filter);
                        break;
                }
            }
        }
    }
}

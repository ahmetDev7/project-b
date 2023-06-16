public static class MenuAccess
{
    private static string _path = "DataSources/Dishes.csv";


    public static void SetPath(string path){
        _path = path;
    }

    public static bool DishMenuExists()
    {
        return File.Exists(_path);
    }


    public static void ShowDishMenu()
    {
        if (!DishMenuExists())
        {
            Console.WriteLine("Current menu is not available.");
            Console.ReadLine();
            return;
        }

        if (File.Exists(_path))
        {
            string[] lines = File.ReadAllLines(_path);

            if (lines.Length <= 1)
            {
                Console.WriteLine("Current Menu is empty.");
                return;
            }

            Console.WriteLine("Current Menu:");

            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine($"Dish #{i}");
                string[] fields = lines[i].Split(';');
                string title = fields[0];
                string ingredients = fields[1];
                string category = fields[2];
                string description = fields[3];
                string price = fields[4];
                string country = fields[5];
                string month = fields[6];

                Console.WriteLine($"{title} - {category}");
                Console.WriteLine($"Ingredients: {ingredients}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine($"Country: {country}");
                Console.WriteLine($"Month: {month}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Current Menu is empty.");
        }
    }

    public static void AddToMenu(string title, string ingredients, string category, string description, string price, string country, string month)
    {
        try
        {

            // Check if the file exists
            bool fileExists = File.Exists(_path);

            // Read existing lines from the file
            List<string> lines = new List<string>();

            if (fileExists)
            {
                lines = File.ReadAllLines(_path).ToList();
            }

            // Insert the new line at the appropriate position
            if (lines.Count <= 1 || string.IsNullOrEmpty(lines[1]))
            {
                lines.Insert(1, $"{title};{ingredients};{category};{description};{price};{country};{month}");
            }
            else
            {
                lines.Add($"{title};{ingredients};{category};{description};{price};{country};{month}");
            }

            // Write the updated lines back to the file
            File.WriteAllLines(_path, lines);

        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding the dish to the Current Menu.", ex);
        }
    }

    public static void EditDishInMenu(int line, string title, string ingredients, string category, string description, string price, string country, string month)
    {
        try
        {

            if (!DishMenuExists())
            {
                Console.WriteLine("Menu is not available.");
                Console.ReadLine();
                return;
            }

            string[] lines = File.ReadAllLines(_path);

            if (line >= 1 && line < lines.Length)
            {
                lines[line] = $"{title};{ingredients};{category};{description};{price};{country};{month}";
                File.WriteAllLines(_path, lines);

                Console.WriteLine("Dish updated on the Current Menu.");
            }
            else
            {
                Console.WriteLine("Invalid line number.");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while editing the dish on the current Menu.", ex);
        }
    }

    public static bool ShowDishTitles()
    {
        if (!File.Exists(_path))
        {
            Console.WriteLine("Current Menu is not available.");
            return false;
        }

        string[] lines = File.ReadAllLines(_path);

        if (lines.Length <= 1)
        {
            Console.WriteLine("Menu is empty.");
            return false;
        }

        Console.WriteLine("Dish Titles:");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(';');
            string title = fields[0];

            Console.WriteLine($"{i}. {title}");
        }

        return true;
    }
    
    public static void ClearDishMenu()
    {
        try
        {
            // Check if the file exists
            if (File.Exists(_path))
            {
                // Read the header line
                string header = File.ReadLines(_path).First();

                // Overwrite the file with the header line
                File.WriteAllText(_path, header + Environment.NewLine);

                Console.WriteLine("Menu file cleared. The current menu is now empty");
            }
            else
            {
                Console.WriteLine("Menu is already empty");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while clearing the menu file.", ex);
        }
    }
}
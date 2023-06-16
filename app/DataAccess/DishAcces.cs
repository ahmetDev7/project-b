public static class DishesDataAccess
{
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
}

public static class DishesDataAccessMonth
{

    public static bool FutureMenuExists(string filePath = "DataSources/FutureMenu.csv")
    {
        return File.Exists(filePath);
    }
    public static void ShowFutureMenu(string filePath = "DataSources/FutureMenu.csv")
    {
        if (!FutureMenuExists())
        {
            Console.WriteLine("Monthly menu is not available.");
            Console.ReadLine();
            return;
        }

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length <= 1)
            {
                Console.WriteLine("Monthly Menu is empty.");
                return;
            }

            Console.WriteLine("Monthly Menu:");

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
            Console.WriteLine("Monthly Menu is empty.");
        }
    }

    public static void AddDishToFutureMenu(string title, string ingredients, string category, string description, string price, string country, string month, string filePath = "DataSources/FutureMenu.csv")
    {
        try
        {

            // Check if the file exists
            bool fileExists = File.Exists(filePath);

            // Read existing lines from the file
            List<string> lines = new List<string>();

            if (fileExists)
            {
                lines = File.ReadAllLines(filePath).ToList();
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
            File.WriteAllLines(filePath, lines);

        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding the dish to the Monthly Menu.", ex);
        }
    }

    public static void EditDishOnFutureMenu(int line, string title, string ingredients, string category, string description, string price, string country, string month, string filePath = "DataSources/FutureMenu.csv")
    {
        try
        {

            if (!FutureMenuExists())
            {
                Console.WriteLine("Monthly menu is not available.");
                Console.ReadLine();
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            if (line >= 1 && line < lines.Length)
            {
                lines[line] = $"{title};{ingredients};{category};{description};{price};{country};{month}";
                File.WriteAllLines(filePath, lines);

                Console.WriteLine("Dish updated on the Monthly Menu.");
            }
            else
            {
                Console.WriteLine("Invalid line number.");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while editing the dish on the Monthly Menu.", ex);
        }
    }

    public static bool ShowDishTitles(string filePath = "DataSources/FutureMenu.csv")
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Monthly Menu is not available.");
            return false;
        }

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length <= 1)
        {
            Console.WriteLine("Monthly Menu is empty.");
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
    public static void DeleteMenuFile(string filePath = "DataSources/FutureMenu.csv")
    {
        try
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the header line
                string header = File.ReadLines(filePath).First();

                // Overwrite the file with the header line
                File.WriteAllText(filePath, header + Environment.NewLine);

                Console.WriteLine("Menu file cleared. The next month Menu is now empty.");
            }
            else
            {
                Console.WriteLine("The Month Menu is already empty.");
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while clearing the menu file.", ex);
        }
    }
}


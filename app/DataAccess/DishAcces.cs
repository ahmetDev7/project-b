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
        public static bool FutureMenuExists()
        {
            return File.Exists("DataSources/FutureMenu.csv");
        }
        public static void ShowFutureMenu()
    {
        if (!FutureMenuExists())
        {
            Console.WriteLine("Future menu is not available.");
            Console.ReadLine();
            return;
        }

        string filePath = "DataSources/FutureMenu.csv";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            Console.WriteLine("Future Menu:");

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
            Console.WriteLine("Future Menu is empty.");
        }
    }

        public static void AddDishToFutureMenu(string title, string ingredients, string category, string description, string price, string country, string month)
    {
        try
        {
            string filePath = "DataSources/FutureMenu.csv";

            // Check if the file exists
            bool fileExists = File.Exists(filePath);

            // Create a new file or append to an existing file
            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                // If the file is newly created, write the header
                if (!fileExists)
                {
                    file.WriteLine("Title;Ingredients;Category;Description;Price;Country;Month");
                }

                // Write the new dish entry
                file.WriteLine($"{title};{ingredients};{category};{description};{price};{country};{month}");
            }

            Console.WriteLine("Dish added to the Future Menu.");
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding the dish to the Future Menu.", ex);
        }
    }

        public static void EditDishOnFutureMenu(int line, string title, string ingredients, string category, string description, string price, string country, string month)
        {
            try
            {
                string filePath = "DataSources/FutureMenu.csv";

                if (!FutureMenuExists())
                {
                    Console.WriteLine("Future menu is not available.");
                    Console.ReadLine();
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

                if (line >= 1 && line < lines.Length)
                {
                    lines[line] = $"{title};{ingredients};{category};{description};{price};{country};{month}";
                    File.WriteAllLines(filePath, lines);

                    Console.WriteLine("Dish updated on the Future Menu.");
                }
                else
                {
                    Console.WriteLine("Invalid line number.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while editing the dish on the Future Menu.", ex);
            }
        }

            public static void ShowDishTitles()
    {
        string[] lines = File.ReadAllLines("DataSources/FutureMenu.csv");

        Console.WriteLine("Dish Titles:");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(';');
            string title = fields[0];

            Console.WriteLine($"{i}. {title}");
        }
    }
    public static void DeleteMenuFile()
{
    try
    {
        string filePath = "DataSources/FutureMenu.csv";

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Delete the file
            File.Delete(filePath);
            Console.WriteLine("Menu file deleted. The Future Menu is no longer available.");
        }
        else
        {
            Console.WriteLine("Menu file does not exist. The Future Menu is already empty.");
        }
    }
    catch (Exception ex)
    {
        throw new ApplicationException("An error occurred while deleting the menu file.", ex);
    }
}
}



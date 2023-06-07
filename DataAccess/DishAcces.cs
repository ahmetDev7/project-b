public static class DishesDataAccess
{
    public static void AddDishToMenu(string Title, string Ingredients, string Catagory, string Discription, string Price, string Country, string Month)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("DataSources/NextMonthDishes.csv", true))
            {
                file.WriteLine(Title + ";" + Ingredients + ";" + Catagory + ";" + Discription + ";" + Price + ";" + Country + ";" + Month);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("This program did an oopsie :", ex);
        }
    }
    public static void ShowInfoMenu(int line)
    {
        string filePaths = "DataSources/NextMonthDishes.csv";
        string[] lines = File.ReadAllLines(filePaths);
        string[] fields = lines[line].Split(';');
        string Title = fields[0];
        string Ingredients = fields[1];
        string Catagory = fields[2];
        string Discription = fields[3];
        string price = fields[4];
        string Country = fields[5];
        string Month = fields[6];

        Console.WriteLine($"\u001b[0m{Title}\n€{price}\n{Ingredients}\n{Catagory} {Country}\n\n{Discription}");
    }
    public static string[] GetLines()
    {
        string filePath = "DataSources/NextMonthDishes.csv";
        string[] lines = File.ReadAllLines(filePath);
        return lines;
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



public static class DishesDataAccess
{
    public static void AddDishToMenu(string Title, string Ingredients, string Catagory, string Discription, string Price)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/DataModels/Dishes.csv", true))
            {
                file.WriteLine(Title + ";" + Ingredients + ";" + Catagory + ";" + Discription + ";" + Price);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("This program did an oopsie :", ex);
        }
    }
    public static void ShowInfoMenu(int line)
    {
        string filePaths = @"/DataModels/Dishes.csv";
        string[] lines = File.ReadAllLines(filePaths);
        string[] fields = lines[line].Split(';');
        string Title = fields[0];
        string Ingredients = fields[1];
        string Catagory = fields[2];
        string Discription = fields[3];
        string price = fields[4];

        Console.WriteLine($"\u001b[0m{Title}\n€{price}\n{Ingredients}\n{Catagory}\n\n{Discription}");
    }
    public static string[] GetLines()
    {
        string filePath = @"/DataModels/Dishes.csv";
        string[] lines = File.ReadAllLines(filePath);
        return lines;
    }
}
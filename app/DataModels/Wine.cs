public class Wine
{
    public string Title { get; set; }
    public string[] Ingredients { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Country { get; set; }
    public string Month { get; set; }

    public Wine(string title, string[] ingredients, string category, string description, double price, string country, string month)
    {
        Title = title;
        Ingredients = ingredients;
        Category = category;
        Description = description;
        Price = price;
        Country = country;
        Month = month;
    }
}

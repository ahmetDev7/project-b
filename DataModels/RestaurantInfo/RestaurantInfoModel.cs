public class RestaurantInfoModel
{
    public string RestaurantName { get; set; }

    public string Description { get; set; }

    public Dictionary<string, string> OpeningHours { get; set; }
    public RestaurantInfoModel(string restaurantname, string description)
    {
        RestaurantName = restaurantname;
        Description = description;
        OpeningHours = new Dictionary<string, string>();
    }
}
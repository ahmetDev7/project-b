using System.Text.Json.Serialization;

public class RestaurantInfoModel
{
    [JsonPropertyName("RestaurantName")]
    public string RestaurantName { get; set; }

    [JsonPropertyName("Description")]
    public string Description { get; set; }

    [JsonPropertyName("OpeningHours")]
    public Dictionary<string, string> OpeningHours { get; set; }
    public RestaurantInfoModel(string restaurantname, string description)
    {
        RestaurantName = restaurantname;
        Description = description;
        OpeningHours = new Dictionary<string, string>();
    }
}
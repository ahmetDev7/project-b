public class RestaurantInfoLogic
{
    RestaurantInfoModel restaurantInfoModel = new("Jake's Restaurant", "Restaurant information");
    
    public string GetRestaurantName()
    {
        return restaurantInfoModel.RestaurantName;
    }
    
    public string GetRestaurantDescription()
    {
        return restaurantInfoModel.Description;
    }

    public string GetOpeningHourPerDay(string day)
    {
        return restaurantInfoModel.OpeningHours[day];   
    }

    public void AddOpeningHours(string day, string hours)
    {
        restaurantInfoModel.OpeningHours.Add(day, hours);
    }
}
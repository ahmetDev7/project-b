using System.ComponentModel.DataAnnotations;

public class RestaurantInfoLogic
{
    RestaurantInfoModel restaurantInfoModel = new("Jake's Restaurant", "Restaurant information");
    List<RestaurantInfoModel> restaurantInfoList = JsonDataAccessor<RestaurantInfoModel>.LoadData("DataSources/RestaurantInfo.json");

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

    public void addRestaurantInfo(string name, string description)
    {
        RestaurantInfoModel model = new(name, description);
        JsonDataAccessor<RestaurantInfoModel>.WriteData("DataSources/RestaurantInfo.json", model);
    }

    public void AddOpeningHours(string day, string hours)
    {
        restaurantInfoModel.OpeningHours.Add(day, hours);
    }

    public void editRestaurantInfo(List<RestaurantInfoModel> modelList)
    {
        JsonDataAccessor<RestaurantInfoModel>.WriteData("DataSources/RestaurantInfo.json", modelList);
    }

    public List<RestaurantInfoModel> LoadRestaurantInfo()
    {
        return restaurantInfoList;
    }
}
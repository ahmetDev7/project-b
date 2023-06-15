using Newtonsoft.Json;
public static class JsonDataAccessor<T>
{   
    // Loading the data into a list.
    public static List<T>? LoadData(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Missing JSON file. {ex.Message}");
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine($"Invalid JSON. {ex.Message}");
        }
        return null;
    }
    // Method overloading: passing a list as argument, which writes the data to the JSONFile.
    public static void WriteData(string filePath, List<T> RandomList)
    {
        string json = JsonConvert.SerializeObject(RandomList, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    // Method overloading: passing an object as argument, which writes the data to the JSONFile.
    public static void WriteData(string filePath, T RandomItem)
    {
        string json = JsonConvert.SerializeObject(RandomItem, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}

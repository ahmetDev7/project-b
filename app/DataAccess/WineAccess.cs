public class WineAccess
{
    private string _path = "DataSources/Wine.csv";

    public List<Wine> ReadCSV(string filePath)
    {
        List<string[]> lines = new List<string[]>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if(!line.Contains("Title")){
                    string[] values = line.Split(',');
                    lines.Add(values);
                }
            }
        }

        WineList wineList = new();


        foreach(var line in lines){
            string title = line[0];
            string[] ingredients = line[1].Split(",").ToArray();
            string category = line[2];
            string description = line[3];
            double price =  double.Parse(line[4]);
            string country = line[5];
            string month = line[6];
            
            Wine wine = new(title, ingredients, category, description, price, country, month);

            wineList.AddWine(wine);
        }

        return wineList;
    }





}
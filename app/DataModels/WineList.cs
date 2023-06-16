public class WineList : List<Wine>
{
    public List<Wine> Wines { get; set; }

    public WineList()
    {
        Wines = new List<Wine>();
    }

    public void AddWine(Wine wine)
    {
        Wines.Add(wine);
    }

    public void EditWine(int index, Wine updatedWine)
    {
        if (index >= 0 && index < Wines.Count)
        {
            Wines[index] = updatedWine;
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid index. Cannot edit wine.");
        }
    }

    public void DeleteWine(int index)
    {
        if (index >= 0 && index < Wines.Count)
        {
            Wines.RemoveAt(index);
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid index. Cannot delete wine.");
        }
    }
}

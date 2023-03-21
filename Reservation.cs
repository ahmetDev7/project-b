public class Reservation
{
    public string Name { get; private set; }
    public int NumberOfPeople { get; private set; }

    public DateTime Time { get; private set; }

    public Reservation(string name, int numberOfPeople, DateTime time)
    {
        Name = name;
        NumberOfPeople = numberOfPeople;
        Time = time;
    }
}
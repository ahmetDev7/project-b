public class Reservation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NumberOfPeople { get; private set; }
    public DateTime Time { get; private set; }
    public int TableNumber { get; set; }
    public Reservation(string firstName, string lastName, int numberOfPeople, DateTime time, int tableNuber)
    {
        FirstName = firstName;
        LastName = lastName;
        NumberOfPeople = numberOfPeople;
        Time = time;
        TableNumber = tableNuber;
    }
}
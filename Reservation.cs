public class Reservation
{
    private string FirstName { get; set; }
    private string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public int NumberOfPeople { get; private set; }
    public DateTime Time { get; private set; }
    private List<Reservation> reservations = JsonDataAccessor<Reservation>.LoadData("JsonFiles/Reservations.json") ?? new List<Reservation>();

    public Reservation(string firstName, string lastName, int numberOfPeople, DateTime time)
    {
        FirstName = firstName;
        LastName = lastName;
        NumberOfPeople = numberOfPeople;
        Time = time;
    }

}
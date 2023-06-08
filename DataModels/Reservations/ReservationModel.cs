public class Reservation
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int NumberOfPeople { get; private set; }
    public DateTime Time { get; private set; }
    public int TableNumber { get; set; }
    public int ReservationCode { get; set; }
    // Constructor for reserving a single table.
    public Reservation(string firstName, string lastName, int numberOfPeople, DateTime time, int tableNumber, int reservationCode)
    {
        FirstName = firstName;
        LastName = lastName;
        NumberOfPeople = numberOfPeople;
        Time = time;
        TableNumber = tableNumber;
        ReservationCode = reservationCode;
    }

    public static int GenerateReservationCode()
    {
        Random random = new Random();

        while (true)
        {
            int reservationCode = random.Next(1000, 10000);
            if (!ReservationList.CheckReservationCode(reservationCode))
            {
                return reservationCode;
            }
        }
    }
}
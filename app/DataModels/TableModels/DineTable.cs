public class DineTable : ISeatable
{
    public int TableNumber { get; set; }
    public int Capacity => _capacity;
    public bool Available { get; set; }
    public Reservation? Reservation { get; set; }

    private int _capacity;

    public DineTable(int tableNumber, int capacity)
    {
        TableNumber = tableNumber;
        _capacity = capacity;
        Available = true;
    }

    public void ReserveTable(string firstName, string lastName, int numberOfPeople, DateTime time, int tableNumber, int ReservationCode, int userid)
    {
        if (!Available)
        {
            throw new InvalidOperationException("Table is already reserved.");
        }

        Reservation = new Reservation(firstName, lastName, numberOfPeople, time, tableNumber, ReservationCode, userid);
        ReservationList.AddReservation(Reservation);
        Available = false;
    }

    public void ReleaseTable()
    {
        if (Available)
        {
            throw new InvalidOperationException("Table is not reserved.");
        }
        ReservationList.RemoveReservation(Reservation!);
        Reservation = null;
        Available = true;
    }
}
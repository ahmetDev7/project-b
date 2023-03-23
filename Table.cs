public class Table
{
    public int TableNumber { get; private set; }
    public int Capacity { get; private set; }
    public bool Available { get; private set; }
    public Reservation? Reservation { get; private set; }

    public Table(int tableNumber, int capacity)
    {
        TableNumber = tableNumber;
        Capacity = capacity;
        Available = true;
    }

    public void ReserveTable(string firstName, string lastName, int numberOfPeople, DateTime time)
    {
        if (!Available)
        {
            throw new InvalidOperationException("Table is already reserved.");
        }

        Reservation = new Reservation(firstName, lastName, numberOfPeople, time);
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
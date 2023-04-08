class BarSeat : ISeatable
{
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public bool Available { get; set; }
    public Reservation? Reservation { get; set; }

    public BarSeat(int tableNumber, int capacity)
    {
        TableNumber = tableNumber;
        Capacity = capacity;
        Available = true;
    }

    public void ReserveTable(string firstName, string lastName, int numberOfPeople, DateTime time, int tableNumber)
    {
        if (!Available)
        {
            throw new InvalidOperationException("Table is already reserved.");
        }

        Reservation = new Reservation(firstName, lastName, numberOfPeople, time, tableNumber);
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
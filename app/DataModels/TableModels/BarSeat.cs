class BarSeat : ISeatable
{
    public int TableNumber { get; set; }
    public int Capacity => 1;
    public bool Available { get; set; }
    public Reservation? Reservation { get; set; }

    public BarSeat(int tableNumber)
    {
        TableNumber = tableNumber;
        Available = true;
    }

    public void ReserveTable(string firstName, string lastName, int numberOfPeople, DateTime time, int tableNumber, int reservationCode, int userid)
    {
        if (!Available)
        {
            throw new InvalidOperationException("Table is already reserved.");
        }

        Reservation = new Reservation(firstName, lastName, numberOfPeople, time, tableNumber, reservationCode, userid);
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
public static class ReservationList
{
    private static List<Reservation> _reservations = JsonDataAccessor<Reservation>.LoadData("DataSources/Reservations.json") ?? new List<Reservation>();
    // overloaded constructor where it takes no arguments and loads the json to the class's reservation list.
    // Adds the reservation to the list and writes it to the json file.
    public static void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
        JsonDataAccessor<Reservation>.WriteData("DataSources/Reservations.json", _reservations);
    }
    // removes the reservation to the list and writes it to the json file.
    public static void RemoveReservation(Reservation reservation)
    {
        _reservations.Remove(reservation);
        JsonDataAccessor<Reservation>.WriteData("DataSources/Reservations.json", _reservations);
    }
}
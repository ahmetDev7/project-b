public static class ReservationList
{
    public static List<Reservation> _reservations = JsonDataAccessor<Reservation>.LoadData("DataSources/Reservations.json") ?? new List<Reservation>();
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

    public static void DeleteReservationByTableNumber(int tableNumber)
    {
        var reservation = _reservations.FirstOrDefault(r => r.TableNumber == tableNumber);
        if (reservation != null)
        {
            _reservations.Remove(reservation);
            JsonDataAccessor<Reservation>.WriteData("DataSources/Reservations.json", _reservations);
        }
    }
    public static void DeleteAllReservations()
    {
        _reservations.Clear();
        JsonDataAccessor<Reservation>.WriteData("DataSources/Reservations.json", _reservations);
    }
    public static bool CheckReservationCode(int rscode)
    {
        bool reservationExists = _reservations?.Any(r => r.ReservationCode == rscode) ?? false;
        while (true)
        if (reservationExists)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
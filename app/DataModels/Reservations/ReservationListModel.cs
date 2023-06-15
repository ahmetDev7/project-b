public static class ReservationList
{
    public static List<Reservation> _reservations = JsonDataAccessor<Reservation>.LoadData("DataSources/Reservations.json") ?? new List<Reservation>();

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

    public static void DeleteReservationByTableNumber(int tableNumber, DateTime date)
    {
        var reservationsToRemove = _reservations.Where(r => r.TableNumber == tableNumber && r.Time.Date == date.Date).ToList();
        foreach (var reservation in reservationsToRemove)
        {
            _reservations.Remove(reservation);
        }
        JsonDataAccessor<Reservation>.WriteData("DataSources/Reservations.json", _reservations);
    }

    public static void DeleteAllReservations(DateTime date)
    {
        var reservationsToRemove = _reservations.Where(r => r.Time.Date == date.Date).ToList();
        foreach (var reservation in reservationsToRemove)
        {
            _reservations.Remove(reservation);
        }
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
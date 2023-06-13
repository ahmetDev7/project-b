public class CustomerResView
{
    public void CustomerResViewMenu()
    {
        var reservations = ReservationList._reservations.Where(reservation => reservation.UserId == Ultilities.roleManager.UserId);
        Console.Clear();
        Console.WriteLine("List of all reservations:\n");
        foreach (var reservation in reservations){
            Console.WriteLine($"Firstname: {reservation.FirstName}");
            Console.WriteLine($"Lastname: {reservation.LastName}");
            Console.WriteLine($"Number of people: {reservation.NumberOfPeople}");
            Console.WriteLine($"Time: {reservation.Time}");
            Console.WriteLine($"Table number: {reservation.TableNumber}");
            Console.WriteLine($"Reservation code: {reservation.ReservationCode}");
            Console.WriteLine("--------------------------");
        }
        Console.WriteLine("Press enter to return back to home.");
        Console.ReadKey();
    }
}
class ProgramTesting
{
    public static void Main(string[] args)
    {
        Admin Dennis = new("DennisZhu", "Testpassword", "TestMail@gmail.com");
        Dennis.GetUsers();
        Restaurant restaurant = new("Jacks restaurant");
        restaurant.MakeReservation();
    }
}
public interface ISeatable
{
   int TableNumber { get; set; }
   int Capacity { get; set; }
   bool Available { get; set; }
   Reservation? Reservation { get; set; }
   void ReserveTable(string firstName, string lastName, int numberOfPeople, DateTime time, int tableNumber, int ReservationCode, int userid);
   void ReleaseTable();
}
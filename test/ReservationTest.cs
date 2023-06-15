using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[TestClass]
public class ReservationTest
{
    ReservationMenuView testreservationMenu = new ReservationMenuView();

    List<ISeatable> tables = Ultilities.restaurant.Seats;
    int ReservationCode = Reservation.GenerateReservationCode();
    
    [TestMethod]
    public void TestReservation()
    {
        // Arrange
        int tableNumberInput = 1;
        string timeInput = "12:00";
        string firstNameInput = "John";
        string lastNameInput = "Doe";
        int numberOfPeopleInput = 4;
        DateTime time = DateTime.MinValue;
        time = DateTime.Parse(timeInput);
        
        // Act
        bool tableAvailable = !ReservationList._reservations.Any(reservation => reservation.TableNumber == tableNumberInput);
        ISeatable table = tables[tableNumberInput- 1];
        if(tableAvailable)
        {
           table.ReserveTable(firstNameInput, lastNameInput, numberOfPeopleInput, time, tableNumberInput, ReservationCode, Ultilities.roleManager.UserId);
         string jsonpath = "DataSources/Reservations.json";

            // Read the JSON file
            string jsonContent = File.ReadAllText(jsonpath);

            // Create an empty JSON array
            JArray jsonArray = new JArray();

            // Write the empty JSON array back to the file
            File.WriteAllText(jsonpath, jsonArray.ToString());
        }
        else
        {
            string jsonpath = "DataSources/Reservations.json";

        // Read the JSON file
        string jsonContent = File.ReadAllText(jsonpath);

        // Create an empty JSON array
        JArray jsonArray = new JArray();

        // Write the empty JSON array back to the file
        File.WriteAllText(jsonpath, jsonArray.ToString());
            bool condition = false;
        Assert.IsTrue(condition, "The condition is false.");
        }
    }
}

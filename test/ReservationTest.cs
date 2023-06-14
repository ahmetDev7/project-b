using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

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
         
        }
        else
        {
            bool condition = false;
        Assert.IsTrue(condition, "The condition is false.");
        }


    }
    //empty json file after test
}
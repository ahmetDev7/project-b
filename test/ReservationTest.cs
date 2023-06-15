using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class ReservationMenuViewTests
{
    private StringWriter consoleOutput;
    private StringReader consoleInput;

    [TestInitialize]
    public void Initialize()
    {
        // Initialize StringWriter to capture console output
        consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
    }

    [TestMethod]
    public void ViewReservationMenu_WhenValidInputProvided_ShouldMakeReservation()
    {
        // Arrange
        ReservationMenuView reservationMenu = new ReservationMenuView();

        // Set up test data
        string tableNumberInput = "1";
        string timeInput = "12:00";
        string firstNameInput = "John";
        string lastNameInput = "Doe";
        string numberOfPeopleInput = "4";
        
        // Redirect the standard input to read from the string
        string input = $"{tableNumberInput}\n{timeInput}\n{firstNameInput}\n{lastNameInput}\n{numberOfPeopleInput}\n2\nt\nt\nt";
        Console.SetIn(new StringReader(input));

        // Act
        reservationMenu.ViewReservationMenu();

        // Assert
        string expectedOutput = $"Table 1 is reserved for {firstNameInput} {lastNameInput} at 12:00\n";
        Assert.AreEqual(expectedOutput, consoleOutput.ToString());
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Clean up StringWriter and StringReader
        consoleOutput.Dispose();
        consoleInput.Dispose();
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class FutureMenuTest
{
    [TestMethod] //Tests if you can ADD Dishes to the menu
    public void AddDishToMenu_ShouldAddDishToMenu()
    {
        // Arrange
        string title = "Creamy Broccoli Vegan Pasta";
        string ingredients = "White beans,Lemon juice,Herbs,Vegetable broth,Pasta,Broccoli,pine nuts";
        string category = "Vegan";
        string description = "While this sauce looks like a rich cream or cheese sauce, it’s actually a tangy, luscious blend of white beans, lemon juice, and nutritional yeast.";
        string price = "8";
        string country = "Italy";
        string month = "April";

        // Act
        DishesDataAccessMonth.AddDishToFutureMenu(title, ingredients, category, description, price, country, month, "DataSources/FutureMenu.csv");
        
        // Assert
        string filePath = "DataSources/FutureMenu.csv";
        string[] lines = File.ReadAllLines(filePath);
        string lastLine = lines[lines.Length - 1]; // Assuming the added dish is the last line in the file
        string[] fields = lastLine.Split(';');
        string actualTitle = fields[0];
        string actualIngredients = fields[1];
        string actualCategory = fields[2];
        string actualDescription = fields[3];
        string actualPrice = fields[4];
        string actualCountry = fields[5];
        string actualMonth = fields[6];

        Assert.AreEqual(title, actualTitle);
        Assert.AreEqual(ingredients, actualIngredients);
        Assert.AreEqual(category, actualCategory);
        Assert.AreEqual(description, actualDescription);
        Assert.AreEqual(price, actualPrice);
        Assert.AreEqual(country, actualCountry);
        Assert.AreEqual(month, actualMonth);
    }
}
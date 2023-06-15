using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[TestClass]
public class FoodTester
{
    [TestMethod]
    public void Foodtest()
    {
        // Arrange
        string csvfile = "DataSources/Datatest.csv";
 
        // Act
        var result = DishesDataAccess.CsvToClass(csvfile);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);

        var firstDish = result.FirstOrDefault();
        Assert.IsNotNull(firstDish);
        Assert.AreEqual(1, firstDish.ID);
        Assert.AreEqual("Dish 1", firstDish.Title);
        CollectionAssert.AreEqual(new string[] { "Ingredient 1", "Ingredient 2" }, firstDish.Ingredients);
        Assert.AreEqual("Category 1", firstDish.Category);
        Assert.AreEqual("Description 1", firstDish.Description);
        Assert.AreEqual(10.5, firstDish.Price);
        Assert.AreEqual("Country 1", firstDish.Country);
        Assert.AreEqual("January", firstDish.Month);

        var secondDish = result.Skip(1).FirstOrDefault();
        Assert.IsNotNull(secondDish);
        Assert.AreEqual(2, secondDish.ID);
        Assert.AreEqual("Dish 2", secondDish.Title);
        CollectionAssert.AreEqual(new string[] { "Ingredient 3", "Ingredient 4" }, secondDish.Ingredients);
        Assert.AreEqual("Category 2", secondDish.Category);
        Assert.AreEqual("Description 2", secondDish.Description);
        Assert.AreEqual(15.75, secondDish.Price);
        Assert.AreEqual("Country 2", secondDish.Country);
        Assert.AreEqual("February", secondDish.Month);
    }    
}

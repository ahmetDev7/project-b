using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LogicDishes
{
    public static void Add()
    {
        Console.WriteLine("Enter dish name: ");
        string title = Console.ReadLine()!;
        Console.WriteLine("Enter dish ingredients seperated by a ',': ");
        string ingredient = Console.ReadLine()!;
        Console.WriteLine("Enter dish catagory");
        string catagory = Console.ReadLine()!;
        Console.WriteLine("Enter dish discription");
        string discription = Console.ReadLine()!;
        Console.WriteLine("Enter dish price");
        string price = Console.ReadLine()!;
        Console.WriteLine("Enter dish county");
        string county = Console.ReadLine()!;
        Console.WriteLine("Enter Month");
        string Month = Console.ReadLine()!;
        DishesDataAccess.AddDishToMenu(title, ingredient, catagory, discription, price, county, Month);

    }

    public static void ShowDishesMenu()
    {

    }
    public static void ShowInfoDishesMenu()
    {

    }
}
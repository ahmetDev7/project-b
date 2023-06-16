using System;
using System.Text;
using static RemoveReservationView;
using System.Globalization;

public static class NavigationMenuView
{
    public static void Menu()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        (int left, int top) = Console.GetCursorPosition();
        int selectedOption = 1;
        bool isMenuOpen = true;
        RestaurantLogic restaurant = new("Jacks restaurant");
        var decorator = $"\u001B[34m>  ";
        Console.Clear();

        while (isMenuOpen)
        {
            Console.SetCursorPosition(left, top);

            if (!Ultilities.roleManager.IsLoggedIn)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to Jake's Restaurant!\nYou are currently not logged in.\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Log in\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Create an account\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Reserve table\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Show Menu\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Show Map\u001b[0m");
                Console.WriteLine($"{(selectedOption == 6 ? decorator : "   ")}Restaurant information\u001b[0m");
                Console.WriteLine($"{(selectedOption == 7 ? decorator : "   ")}Quit the program\u001b[0m");
            }
            // User role has logged in.
            else if (Ultilities.roleManager.IsLoggedIn && Ultilities.roleManager.CurrentUserRole == "user")
            {
                Console.Clear();
                Console.WriteLine($"Customer, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Reserve table\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Show Menu\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Show Map\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Restaurant information\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Show Reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 6 ? decorator : "   ")}Log Out\u001b[0m");
            }
            // Employee role has logged in.
            else if (Ultilities.roleManager.IsLoggedIn && Ultilities.roleManager.CurrentUserRole == "employee")
            {
                Console.Clear();
                Console.WriteLine($"Employee, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}View reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Remove a reservation\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Log Out\u001b[0m");
            }
            // User role has logged in.
            else if (Ultilities.roleManager.IsLoggedIn && Ultilities.roleManager.CurrentUserRole == "admin")
            {
                Console.Clear();
                Console.WriteLine($"Admin, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}View reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Remove a reservation\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Change Restaurant info & opening hours\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Manage Employees\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Manage Menu of The Month\u001b[0m");
                Console.WriteLine($"{(selectedOption == 6 ? decorator : "   ")}Log Out\u001b[0m");
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (!Ultilities.roleManager.IsLoggedIn)
                    {
                        selectedOption = (selectedOption - 1 < 1) ? 7 : selectedOption - 1;
                    }
                    else
                    {
                        switch (Ultilities.roleManager.CurrentUserRole)
                        {
                            case "user":
                                selectedOption = (selectedOption - 1 < 1) ? 6 : selectedOption - 1;
                                break;
                            case "employee":
                                selectedOption = (selectedOption - 1 < 1) ? 3 : selectedOption - 1;
                                break;
                            case "admin":
                                selectedOption = (selectedOption - 1 < 1) ? 6 : selectedOption - 1;
                                break;
                        }
                    }
                    break;
                
                case ConsoleKey.DownArrow:
                    if (!Ultilities.roleManager.IsLoggedIn)
                    {
                        selectedOption = (selectedOption + 1 > 7) ? 1 : selectedOption + 1;
                    }
                    else
                    {
                        switch (Ultilities.roleManager.CurrentUserRole)
                        {
                            case "user":
                                selectedOption = (selectedOption + 1 > 6) ? 1 : selectedOption + 1;
                                break;
                            case "employee":
                                selectedOption = (selectedOption + 1 > 3) ? 1 : selectedOption + 1;
                                break;
                            case "admin":
                                selectedOption = (selectedOption + 1 > 6) ? 1 : selectedOption + 1;
                                break;
                        }
                    }
                    break;
                
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (!Ultilities.roleManager.IsLoggedIn)
                    {
                        if (selectedOption == 1)
                        {
                            Ultilities.login.viewLogin();
                        }
                        else if (selectedOption == 2)
                        {
                            Ultilities.makeNewAccount.ViewMakeNewAccount();
                        }
                        else if (selectedOption == 3)
                        {
                            Ultilities.reservationMenu.ViewReservationMenu();
                        }
                        else if (selectedOption == 4)
                        {
                            FilterMenuView.FilterOptions();
                        }
                        else if (selectedOption == 5)
                        {
                            DateTime date = GetDate();
                            Ultilities.restaurant.PrintTableMap(date);
                            System.Console.Write("Press enter to continue...");
                            Console.ReadKey();
                        }
                        else if (selectedOption == 6)
                        {
                            Console.Clear();
                            Ultilities.restaurantInfo.RestaurantInfoMenu();
                        }
                        else if (selectedOption == 7)
                        {   
                            System.Environment.Exit(1);
                        }
                    }
                    else if (Ultilities.roleManager.IsLoggedIn)
                    {
                        if (Ultilities.roleManager.CurrentUserRole == "user")
                        {
                            if (selectedOption == 1)
                            {
                                Ultilities.reservationMenu.ViewReservationMenu();
                            }
                            else if (selectedOption == 2)
                            {
                                FilterMenuView.FilterOptions();
                            }
                            else if (selectedOption == 3)
                            {
                                DateTime date = GetDate();
                                Ultilities.restaurant.PrintTableMap(date);
                                System.Console.WriteLine("\nPress enter to continue...");
                                Console.ReadLine();
                            }
                            else if (selectedOption == 4)
                            {
                                Console.Clear();
                                Ultilities.restaurantInfo.RestaurantInfoMenu();
                            }
                            
                            else if (selectedOption == 5)
                            {
                                Console.Clear();
                                Ultilities.cusResView.CustomerResViewMenu();
                            }

                            else if (selectedOption == 6)
                            {
                                Ultilities.roleManager.Logout();
                            }
                        }
                        else if (Ultilities.roleManager.CurrentUserRole == "employee")
                        {
                            if (selectedOption == 1)
                            {
                                restaurant.DisplayReservationOverview();
                                System.Console.WriteLine("Press enter to continue...");
                                Console.ReadKey();
                            }
                            else if (selectedOption == 2)
                            {
                                Ultilities.removeReservation.RemoveReservationMenu();
                            }
                            else if (selectedOption == 3)
                            {
                                Ultilities.roleManager.Logout();
                            }
                        }
                        else if (Ultilities.roleManager.CurrentUserRole == "admin")
                        {
                            if (selectedOption == 1)
                            {
                                Ultilities.restaurant.DisplayReservationOverview();
                                System.Console.WriteLine("Press enter to continue...");
                                Console.ReadKey();
                            }
                            else if (selectedOption == 2)
                            {
                                Ultilities.removeReservation.RemoveReservationMenu();
                                
                            }
                            else if (selectedOption == 3)
                            {
                                Ultilities.adminRestaurantInfo.RestaurantInfoAdminMenu();
                            }
                            else if (selectedOption == 4)
                            {
                                Ultilities.manageEmployees.ManageEmployeesMenu();
                            }
                            else if (selectedOption == 5)
                            {
                                //Ultilities.roleManager.Createmenu();
                                Ultilities.futureMenu.FutureMenuOptions();
                            }
                            else if (selectedOption == 6)
                            {
                                Ultilities.roleManager.Logout();
                            }
                        }
                    }
                    break;
            }
        }
    }
    public static DateTime GetDate()
    {
        bool validDate= false;
        DateTime selectedDate = DateTime.MinValue; // Declare the variable outside the while loop
        while (!validDate)
        {
            Console.Write("Enter the day you want to see (MM/dd/yyyy): ");
            string inputDate = Console.ReadLine();

            if (!DateTime.TryParseExact(inputDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out selectedDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in MM/dd/yyyy format.\n");
                continue;
            }
            validDate = true;
        }
        return selectedDate;
    }
}

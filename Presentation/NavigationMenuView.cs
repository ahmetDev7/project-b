using System;
using System.Text;
using static RemoveReservationView;

public static class NavigationMenuView
{
    public static void Menu()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
        (int left, int top) = Console.GetCursorPosition();
        int selectedOption = 1;
        bool isMenuOpen = true;
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
            else if (Ultilities.roleManager.IsLoggedIn && Ultilities.roleManager.CurrentUserRole == "user")
            {
                Console.Clear();
                Console.WriteLine($"Customer, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}Reserve table\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Show Menu\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Show Map\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Restaurant information\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Log Out\u001b[0m");
            }
            else if (Ultilities.roleManager.IsLoggedIn && Ultilities.roleManager.CurrentUserRole == "employee")
            {
                Console.Clear();
                Console.WriteLine($"Employee, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}View reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Remove a reservation\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Log Out\u001b[0m");
            }
            else if (Ultilities.roleManager.IsLoggedIn && Ultilities.roleManager.CurrentUserRole == "admin")
            {
                Console.Clear();
                Console.WriteLine($"Admin, Welcome to Jake's Restaurant!\n\nSelect one of the following options:\n");
                Console.WriteLine($"{(selectedOption == 1 ? decorator : "   ")}View reservations\u001b[0m");
                Console.WriteLine($"{(selectedOption == 2 ? decorator : "   ")}Remove a reservation\u001b[0m");
                Console.WriteLine($"{(selectedOption == 3 ? decorator : "   ")}Change Restaurant info & opening hours\u001b[0m");
                Console.WriteLine($"{(selectedOption == 4 ? decorator : "   ")}Manage Employees\u001b[0m");
                Console.WriteLine($"{(selectedOption == 5 ? decorator : "   ")}Log Out\u001b[0m");
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
                                selectedOption = (selectedOption - 1 < 1) ? 5 : selectedOption - 1;
                                break;
                            case "employee":
                                selectedOption = (selectedOption - 1 < 1) ? 3 : selectedOption - 1;
                                break;
                            case "admin":
                                selectedOption = (selectedOption - 1 < 1) ? 5 : selectedOption - 1;
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
                                selectedOption = (selectedOption + 1 > 5) ? 1 : selectedOption + 1;
                                break;
                            case "employee":
                                selectedOption = (selectedOption + 1 > 3) ? 1 : selectedOption + 1;
                                break;
                            case "admin":
                                selectedOption = (selectedOption + 1 > 5) ? 1 : selectedOption + 1;
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
                            Ultilities.restaurant.PrintTableMap();
                            System.Console.WriteLine("Press enter to continue...");
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
                                Ultilities.restaurant.PrintTableMap();
                                System.Console.WriteLine("Press enter to continue...");
                                Console.ReadKey();
                            }
                            else if (selectedOption == 4)
                            {
                                Console.Clear();
                                Ultilities.restaurantInfo.RestaurantInfoMenu();
                            }

                            else if (selectedOption == 5)
                            {
                                Ultilities.roleManager.Logout();
                            }
                        }
                        else if (Ultilities.roleManager.CurrentUserRole == "employee")
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
                                Ultilities.roleManager.Logout();
                            }
                        }
                    }
                    break;
            }
        }
    }
}

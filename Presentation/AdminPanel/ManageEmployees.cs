public class ManageEmployees
{
    
    public void ManageEmployeesMenu(){
        while (true){
            Console.Clear();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Manage Employees");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1) Add new employee");
            Console.WriteLine("2) Edit employee");
            Console.WriteLine("3) Delete employee");
            Console.WriteLine("4) View all employees");
            Console.WriteLine("5) Return to homepage");
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Enter an option from the menu (from 1-5): ");
            string userInput = Console.ReadLine();
            var employees = AccountManager.users.Where(employee => employee.Role == "employee");
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Type in employee name: ");
                    string employeeName = Console.ReadLine();
                    Console.Write("Type in employee email: ");
                    string employeeEmail = Console.ReadLine();
                    System.Console.Write("Type in employee password: ");
                    string employeePassword = Console.ReadLine();
                    AccountManager.AddUser(new User(employeeName, employeeEmail, employeePassword, "employee"));
                    System.Console.WriteLine($"You successfully created a new employee account!");
                    System.Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("List of all employees:\n");
                    foreach (var employee in employees){
                        Console.WriteLine($"Name: {employee.UserName}");
                        Console.WriteLine($"Email: {employee.Mail}");
                        Console.WriteLine($"Role: {employee.Role}");
                        Console.WriteLine("--------------------------");
                    }
                    Console.Write("\nTo edit an employee enter the email of the employee: ");
                    string editEmployeeEmail = Console.ReadLine();
                    
                    string editEmployeeNameInsert;
                    string editEmployeeEmailInsert;
                    string editEmployeePasswordInsert;
                    
                    User? editFoundAccount = null;
                    editFoundAccount = AccountManager.users.FirstOrDefault(user => user.Mail == editEmployeeEmail);

                    if (editFoundAccount == null)
                    {
                        Console.WriteLine("\nInvalid email, please try again.");
                        Console.ReadKey();
                    } else{
                        editEmployeeNameInsert = editFoundAccount.UserName;
                        editEmployeeEmailInsert = editFoundAccount.Mail;
                        editEmployeePasswordInsert = editFoundAccount.PassWord;

                        Console.Clear();
                        while(true){
                            Console.WriteLine("Do you want to change the name of the employee?");
                            Console.WriteLine("1) Yes");
                            Console.WriteLine("2) No");
                            string userSelection = Console.ReadLine();
                            if (userSelection == "1"){
                                Console.Clear();
                                Console.Write("Type in employee new name: ");
                                editEmployeeNameInsert = Console.ReadLine();
                                break;
                            } else if(userSelection == "2"){
                                break;
                            }
                        }

                        Console.Clear();
                        while(true){
                            Console.WriteLine("Do you want to change the email of the employee?");
                            Console.WriteLine("1) Yes");
                            Console.WriteLine("2) No");
                            string userSelection = Console.ReadLine();
                            if (userSelection == "1"){
                                Console.Clear();
                                Console.Write("Type in employee new email: ");
                                editEmployeeEmailInsert = Console.ReadLine();
                                break;
                            } else if(userSelection == "2"){
                                break;
                            }
                        }

                        Console.Clear();
                        while(true){
                            Console.WriteLine("Do you want to change the password of the employee?");
                            Console.WriteLine("1) Yes");
                            Console.WriteLine("2) No");
                            string userSelection = Console.ReadLine();
                            if (userSelection == "1"){
                                Console.Clear();
                                Console.Write("Type in employee new password: ");
                                editEmployeePasswordInsert = Console.ReadLine();
                                break;
                            } else if(userSelection == "2"){
                                break;
                            }
                        }

                        AccountManager.users.Remove(editFoundAccount);
                        AccountManager.RemoveUser(editFoundAccount);
                        AccountManager.AddUser(new User(editEmployeeNameInsert, editEmployeePasswordInsert, editEmployeeEmailInsert, "employee"));

                        Console.WriteLine($"\nYou have succesfully changed {editEmployeeEmailInsert}!");
                        Console.ReadKey();
                        break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("List of all employees:\n");
                    foreach (var employee in employees){
                        Console.WriteLine($"Name: {employee.UserName}");
                        Console.WriteLine($"Email: {employee.Mail}");
                        Console.WriteLine($"Role: {employee.Role}");
                        Console.WriteLine("--------------------------");
                    }
                    Console.WriteLine("To delete an employee enter the following fields:\n");
                    Console.Write("Type in employee name: ");
                    string delEmployeeName = Console.ReadLine();
                    Console.Write("Type in employee email: ");
                    string delEmployeeEmail = Console.ReadLine();
                    
                    User? foundAccount = null;
                    foundAccount = AccountManager.users.FirstOrDefault(user => user.UserName == delEmployeeName && user.Mail == delEmployeeEmail);
                    if (foundAccount == null)
                    {
                        Console.WriteLine("\nInvalid name or email, please try again.");
                        Console.ReadKey();
                    } else{
                        AccountManager.users.Remove(foundAccount);
                        AccountManager.RemoveUser(foundAccount);
                        Console.WriteLine($"\nYou have succesfully deleted {delEmployeeName} from the system!");
                        Console.ReadKey();
                        break;
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("List of all employees:\n");
                    foreach (var employee in employees){
                        Console.WriteLine($"Name: {employee.UserName}");
                        Console.WriteLine($"Email: {employee.Mail}");
                        Console.WriteLine($"Role: {employee.Role}");
                        Console.WriteLine("--------------------------");
                    }
                    System.Console.WriteLine("\nPress enter to continue...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
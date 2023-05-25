public class LoginView
{
    public void viewLogin()
    {   
        User? foundAccount = null;
        while(true){   
            System.Console.Write("Enter your username: ");
            string userName = Console.ReadLine()!;
            System.Console.Write("Enter your password: ");
            string password = Console.ReadLine()!;
            foundAccount = AccountManager.users.FirstOrDefault(user => user.UserName == userName && user.PassWord == password);
            if (foundAccount == null)
            {
                Console.WriteLine("Invalid username or password, please try again.");
            } else{
                Ultilities.roleManager.Login(foundAccount.Role);
                break;
            }
        }
        Console.Clear();
    }
}
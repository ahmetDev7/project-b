public class LoginView
{
    public void viewLogin()
{   
    User? foundAccount = null;
    while (true)
    {   
        Console.Write("Enter your username: ");
        string userName = Console.ReadLine()!;
        
        Console.Write("Enter your password: ");
        string password = MaskPasswordInput();

        foundAccount = AccountManager.users.FirstOrDefault(user => user.UserName == userName && user.PassWord == password);
        
        if (foundAccount == null)
        {
            Console.WriteLine("Invalid username or password, please try again.");
        }
        else
        {
            Ultilities.roleManager.Login(foundAccount.Role, foundAccount.UserId);
            break;
        }
    }
    Console.Clear();
}

private string MaskPasswordInput()
{
    string password = "";
    ConsoleKeyInfo key;

    do
    {
        key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Backspace)
        {
            if (password.Length > 0)
            {
                password = password.Remove(password.Length - 1);
                Console.Write("\b \b"); // Move cursor back, overwrite character with space, move cursor back again
            }
        }
        else if (key.Key != ConsoleKey.Enter)
        {
            password += key.KeyChar;
            Console.Write("*");
        }
    } while (key.Key != ConsoleKey.Enter);

    Console.WriteLine();
    return password;
}
}
public class MakeNewAccountView
{
    public void ViewMakeNewAccount()
    {
        System.Console.Write("Enter your email: ");
        string mail = Console.ReadLine()!;
        System.Console.Write("Enter an username: ");
        string userName = Console.ReadLine()!;
        System.Console.Write("Enter a password: ");
        string passWord = Console.ReadLine()!;
        AccountManager.AddUser(new User(userName, passWord, mail, "user"));
        System.Console.WriteLine($"Congrats {userName}! You successfully created your account!");
        System.Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}
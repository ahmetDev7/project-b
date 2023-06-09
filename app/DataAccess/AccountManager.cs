public static class AccountManager
{
    public static List<User> users = JsonDataAccessor<User>.LoadData("DataSources/LoginCredentials.json") ?? new List<User>();
    public static void AddUser(User user)
    {
        users.Add(user);
        JsonDataAccessor<User>.WriteData("DataSources/LoginCredentials.json", users);
    }

    public static void RemoveUser(User user)
    {
        users.Remove(user);
        JsonDataAccessor<User>.WriteData("DataSources/LoginCredentials.json", users);
    }
    public static void GetUsers() => users.ForEach(x => System.Console.WriteLine($"Username: {x.UserName}\nEmail: {x.Mail}\n"));
}


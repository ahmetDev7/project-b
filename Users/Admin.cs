class Admin : User
{
    private List<User> users { get; set; } = JsonDataAccessor<User>.LoadData("JsonFiles/LoginCredentials.json") ?? new List<User>();

    public Admin(string userName, string passWord, string mail) : base(userName, passWord, mail)
    {
        if (!users.Any(user => user.UserName == userName))
        {
            AddUser(this);
        }
    }
    // This method allows the admin to change user credentials
    public void ChangeUsersCredentials(User user, string newUserName, string NewPassWord)
    {
        user.UserName = newUserName;
        user.PassWord = NewPassWord;
    }

    public void AddUser(User user)
    {
        users.Add(user);
        JsonDataAccessor<User>.WriteData("JsonFiles/LoginCredentials.json", users);
    }

    public void RemoveUser(User user)
    {
        users.Remove(user);
        JsonDataAccessor<User>.WriteData("JsonFiles/LoginCredentials.json", users);
    }
    public void GetUsers() => users.ForEach(x => System.Console.WriteLine($"Username: {x.UserName}\nEmail: {x.Mail}\n"));
}
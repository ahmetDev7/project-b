class Admin : User
{   
    public Admin(string userName, string passWord, string mail) : base(userName, passWord, mail)
    {
        if (!AccountManager.users.Any(user => user.UserName == userName))
        {
            AccountManager.AddUser(this);
        }
    }
    // This method allows the admin to change user credentials
    public void ChangeUsersCredentials(User user, string newUserName, string NewPassWord)
    {
        user.UserName = newUserName;
        user.PassWord = NewPassWord;
    }
}
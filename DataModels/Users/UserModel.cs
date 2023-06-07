public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public string Mail { get; set; }
    public string Role { get; set; }
    public User(string userName, string passWord, string mail, string role)
    {
        UserName = userName;
        PassWord = passWord;
        Mail = mail;
        Role = role;
    }
    public void ChangeUserName(string newUserName) => UserName = newUserName;
    public void ChangePassWord(string NewPassWord) => PassWord = NewPassWord;
    
}

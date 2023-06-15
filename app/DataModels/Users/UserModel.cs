public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public string Mail { get; set; }
    public string Role { get; set; }
    public int UserId { get; set; }
    public User(string userName, string passWord, string mail, string role, int userid)
    {
        UserName = userName;
        PassWord = passWord;
        Mail = mail;
        Role = role;
        UserId = userid;
    }
    public void ChangeUserName(string newUserName) => UserName = newUserName;
    public void ChangePassWord(string NewPassWord) => PassWord = NewPassWord;
}

public class User
{
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public string Mail { get; set; }
    public User(string userName, string passWord, string mail)
    {
        UserName = userName;
        PassWord = passWord;
        Mail = mail;
    }
    public void ChangeUserName(string newUserName) => UserName = newUserName;
    public void ChangePassWord(string NewPassWord) => PassWord = NewPassWord;
    public virtual void ViewMenu()
    {

    }
    
}

public class UserRoleManager
{   
    private bool loggedIn;
    private string currentUserRole;
    private int userId;

    public bool IsLoggedIn
    {
        get { return loggedIn; }
    }

    public string CurrentUserRole
    {
        get { return currentUserRole; }
    }

    public int UserId
    {
        get { return userId; }
    }

    public void Login(string role, int userid)
    {
        loggedIn = true;
        currentUserRole = role;
        userId = userid;
    }

    public void Logout()
    {
        loggedIn = false;
        currentUserRole = string.Empty;
    }

    public void SwitchRole(string newRole)
    {
        currentUserRole = newRole;
    }
}
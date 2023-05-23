public class UserRoleManager
{   
    private bool loggedIn;
    private string currentUserRole;

    public bool IsLoggedIn
    {
        get { return loggedIn; }
    }

    public string CurrentUserRole
    {
        get { return currentUserRole; }
    }

    public void Login(string role)
    {
        loggedIn = true;
        currentUserRole = role;
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
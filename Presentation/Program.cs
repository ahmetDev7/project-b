class ProgramTesting
{
    public static void Main(string[] args)
    {   
        User user = new("Dennis", "Zhu", "41234124");
        JsonDataAccessor<User>.WriteData("DataSources/LoginCredentials.json", user);
    }
}
public class Admin : Person
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    public Admin(string firstName, string lastName, string username, string password)
        : base(firstName, lastName)
    {
        Username = username;
        Password = password;
    }

    public bool Login(string username, string password)
    {
        return Username == username && Password == password;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Admin: {FirstName} {LastName}");
    }
}

public class Customer : Person
{
    public List<Reservation> Reservations { get; set; }

    public Customer(string firstName, string lastName) : base(firstName, lastName)
    {
        Reservations = new List<Reservation>();
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Customer: {FirstName} {LastName}");
    }
}

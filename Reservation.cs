public class Reservation
{
    public int Id { get; private set; }
    public Customer Customer { get; set; }
    public Showtime Showtime { get; set; }
    public Seat Seat { get; set; }

    public Reservation(int id, Customer customer, Showtime showtime, Seat seat)
    {
        if (id <= 0)
            throw new ArgumentException("Reservation ID must be greater than 0.");

        Id = id;
        Customer = customer;
        Showtime = showtime;
        Seat = seat;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(
            $"Reservation ID: {Id} | " +
            $"Customer: {Customer.FirstName} {Customer.LastName} | " +
            $"Movie: {Showtime.Movie.Name} | " +
            $"Hall: {Showtime.Hall.HallNumber} | " +
            $"Seat: {Seat.SeatNumber} | " +
            $"Time: {Showtime.Time}"
        );
    }
}

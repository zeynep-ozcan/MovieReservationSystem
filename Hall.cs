public class Hall
{
    public int HallNumber { get; private set; }
    public List<Seat> Seats { get; private set; }

    public Hall(int hallNumber, int seatCount)
    {
        if (hallNumber <= 0)
            throw new ArgumentException("Hall number must be greater than 0.");

        if (seatCount <= 0)
            throw new ArgumentException("Seat count must be greater than 0.");

        HallNumber = hallNumber;
        Seats = new List<Seat>();

        for (int i = 1; i <= seatCount; i++)
        {
            Seats.Add(new Seat(i));
        }
    }

    public void DisplaySeats()
    {
        Console.WriteLine($"\nHall {HallNumber} Seat Status:");

        foreach (Seat seat in Seats)
        {
            string status = seat.IsOccupied ? "Occupied" : "Available";
            Console.WriteLine($"Seat {seat.SeatNumber}: {status}");
        }
    }

    public Seat FindSeat(int seatNumber)
    {
        foreach (Seat seat in Seats)
        {
            if (seat.SeatNumber == seatNumber)
                return seat;
        }

        throw new Exception("Seat not found.");
    }
}

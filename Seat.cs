public class Seat
{
    public int SeatNumber { get; private set; }
    public bool IsOccupied { get; private set; }

    public Seat(int seatNumber)
    {
        if (seatNumber <= 0)
            throw new ArgumentException("Seat number must be greater than 0.");

        SeatNumber = seatNumber;
        IsOccupied = false;
    }

    public void Reserve()
    {
        if (IsOccupied)
            throw new Exception("This seat is already occupied.");

        IsOccupied = true;
    }

    public void Cancel()
    {
        if (!IsOccupied)
            throw new Exception("This seat is already empty.");

        IsOccupied = false;
    }
}

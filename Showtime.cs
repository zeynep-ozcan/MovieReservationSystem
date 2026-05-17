public class Showtime
{
    public int Id { get; private set; }
    public Movie Movie { get; set; }
    public Hall Hall { get; set; }
    public string Time { get; set; }

    public Showtime(int id, Movie movie, Hall hall, string time)
    {
        if (id <= 0)
            throw new ArgumentException("Showtime ID must be greater than 0.");

        Id = id;
        Movie = movie;
        Hall = hall;
        Time = time;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Showtime ID: {Id} | Movie: {Movie.Name} | Hall: {Hall.HallNumber} | Time: {Time}");
    }
}

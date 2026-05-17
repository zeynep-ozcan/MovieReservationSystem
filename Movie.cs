public class Movie
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }

    public Movie(int id, string name, string genre, int duration)
    {
        if (id <= 0)
            throw new ArgumentException("Movie ID must be greater than 0.");

        if (duration <= 0)
            throw new ArgumentException("Movie duration must be greater than 0.");

        Id = id;
        Name = name;
        Genre = genre;
        Duration = duration;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id} | Movie: {Name} | Genre: {Genre} | Duration: {Duration} min");
    }
}

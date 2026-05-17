public class FileManager
{
    private static string moviesFile = "movies.txt";
    private static string hallsFile = "halls.txt";
    private static string showtimesFile = "showtimes.txt";
    private static string reservationsFile = "reservations.txt";

    private static string ResolveDataFile(string newFile, string legacyFile)
    {
        if (File.Exists(newFile))
            return newFile;

        if (File.Exists(legacyFile))
            return legacyFile;

        return newFile;
    }

    public static void Save(CinemaSystem system)
    {
        using (StreamWriter movieWriter = new StreamWriter(moviesFile))
        {
            foreach (Movie movie in system.Movies)
            {
                movieWriter.WriteLine($"{movie.Name};{movie.Genre};{movie.Duration}");
            }
        }

        using (StreamWriter hallWriter = new StreamWriter(hallsFile))
        {
            foreach (Hall hall in system.Halls)
            {
                hallWriter.WriteLine($"{hall.HallNumber};{hall.Seats.Count}");
            }
        }

        using (StreamWriter showtimeWriter = new StreamWriter(showtimesFile))
        {
            foreach (Showtime showtime in system.Showtimes)
            {
                showtimeWriter.WriteLine($"{showtime.Movie.Id};{showtime.Hall.HallNumber};{showtime.Time}");
            }
        }

        using (StreamWriter reservationWriter = new StreamWriter(reservationsFile))
        {
            foreach (Reservation reservation in system.Reservations)
            {
                reservationWriter.WriteLine(
                    $"{reservation.Customer.FirstName};{reservation.Customer.LastName};{reservation.Showtime.Id};{reservation.Seat.SeatNumber}"
                );
            }
        }
    }

    public static CinemaSystem Load()
    {
        CinemaSystem system = new CinemaSystem();

        string moviesPath = ResolveDataFile(moviesFile, "filmler.txt");
        if (File.Exists(moviesPath))
        {
            foreach (string line in File.ReadAllLines(moviesPath))
            {
                string[] parts = line.Split(';');

                if (parts.Length == 3)
                {
                    system.AddMovie(
                        parts[0],
                        parts[1],
                        Convert.ToInt32(parts[2])
                    );
                }
            }
        }

        string hallsPath = ResolveDataFile(hallsFile, "salonlar.txt");
        if (File.Exists(hallsPath))
        {
            foreach (string line in File.ReadAllLines(hallsPath))
            {
                string[] parts = line.Split(';');

                if (parts.Length == 2)
                {
                    system.AddHall(
                        Convert.ToInt32(parts[0]),
                        Convert.ToInt32(parts[1])
                    );
                }
            }
        }

        string showtimesPath = ResolveDataFile(showtimesFile, "seanslar.txt");
        if (File.Exists(showtimesPath))
        {
            foreach (string line in File.ReadAllLines(showtimesPath))
            {
                string[] parts = line.Split(';');

                if (parts.Length == 3)
                {
                    system.AddShowtime(
                        Convert.ToInt32(parts[0]),
                        Convert.ToInt32(parts[1]),
                        parts[2]
                    );
                }
            }
        }

        string reservationsPath = ResolveDataFile(reservationsFile, "rezervasyonlar.txt");
        if (File.Exists(reservationsPath))
        {
            foreach (string line in File.ReadAllLines(reservationsPath))
            {
                string[] parts = line.Split(';');

                if (parts.Length == 4)
                {
                    string customerFirstName = parts[0];
                    string customerLastName = parts[1];
                    int showtimeId = Convert.ToInt32(parts[2]);
                    int seatNumber = Convert.ToInt32(parts[3]);

                    Customer customer = new Customer(customerFirstName, customerLastName);

                    try
                    {
                        system.MakeReservation(customer, showtimeId, seatNumber);
                    }
                    catch
                    {
                    }
                }
            }
        }

        return system;
    }
}

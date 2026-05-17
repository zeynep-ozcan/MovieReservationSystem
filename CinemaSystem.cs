public class CinemaSystem
{
    public List<Movie> Movies { get; set; }
    public List<Hall> Halls { get; set; }
    public List<Showtime> Showtimes { get; set; }
    public List<Reservation> Reservations { get; set; }

    private int movieIdCounter = 1;
    private int showtimeIdCounter = 1;
    private int reservationIdCounter = 1;

    public CinemaSystem()
    {
        Movies = new List<Movie>();
        Halls = new List<Hall>();
        Showtimes = new List<Showtime>();
        Reservations = new List<Reservation>();
    }

    public void AddMovie(string name, string genre, int duration)
    {
        Movie movie = new Movie(movieIdCounter, name, genre, duration);
        Movies.Add(movie);
        movieIdCounter++;
    }

    public void ListMovies()
    {
        if (Movies.Count == 0)
        {
            Console.WriteLine("No movies registered.");
            return;
        }

        foreach (Movie movie in Movies)
        {
            movie.DisplayInfo();
        }
    }

    public Movie FindMovie(int id)
    {
        foreach (Movie movie in Movies)
        {
            if (movie.Id == id)
                return movie;
        }

        throw new Exception("Movie not found.");
    }

    public void UpdateMovie(int id, string newName, string newGenre, int newDuration)
    {
        Movie movie = FindMovie(id);

        if (newDuration <= 0)
            throw new ArgumentException("Movie duration must be greater than 0.");

        movie.Name = newName;
        movie.Genre = newGenre;
        movie.Duration = newDuration;
    }

    public void DeleteMovie(int id)
    {
        Movie movie = FindMovie(id);
        Movies.Remove(movie);
    }

    public void AddHall(int hallNumber, int seatCount)
    {
        Hall hall = new Hall(hallNumber, seatCount);
        Halls.Add(hall);
    }

    public void ListHalls()
    {
        if (Halls.Count == 0)
        {
            Console.WriteLine("No halls registered.");
            return;
        }

        foreach (Hall hall in Halls)
        {
            Console.WriteLine($"Hall No: {hall.HallNumber} | Seat Count: {hall.Seats.Count}");
        }
    }

    public Hall FindHall(int hallNumber)
    {
        foreach (Hall hall in Halls)
        {
            if (hall.HallNumber == hallNumber)
                return hall;
        }

        throw new Exception("Hall not found.");
    }

    public void AddShowtime(int filmId, int hallNumber, string time)
    {
        Movie movie = FindMovie(filmId);
        Hall hall = FindHall(hallNumber);

        Showtime showtime = new Showtime(showtimeIdCounter, movie, hall, time);
        Showtimes.Add(showtime);
        showtimeIdCounter++;
    }

    public void ListShowtimes()
    {
        if (Showtimes.Count == 0)
        {
            Console.WriteLine("No showtimes registered.");
            return;
        }

        foreach (Showtime showtime in Showtimes)
        {
            showtime.DisplayInfo();
        }
    }

    public Showtime FindShowtime(int id)
    {
        foreach (Showtime showtime in Showtimes)
        {
            if (showtime.Id == id)
                return showtime;
        }

        throw new Exception("Showtime not found.");
    }

    public void UpdateShowtime(int id, int newFilmId, int newHallNumber, string newTime)
    {
        Showtime showtime = FindShowtime(id);
        Movie movie = FindMovie(newFilmId);
        Hall hall = FindHall(newHallNumber);

        showtime.Movie = movie;
        showtime.Hall = hall;
        showtime.Time = newTime;
    }

    public void DeleteShowtime(int id)
    {
        Showtime showtime = FindShowtime(id);
        Showtimes.Remove(showtime);
    }

    public void MakeReservation(Customer customer, int showtimeId, int seatNumber)
    {
        Showtime showtime = FindShowtime(showtimeId);
        Seat seat = showtime.Hall.FindSeat(seatNumber);

        seat.Reserve();

        Reservation reservation = new Reservation(
            reservationIdCounter,
            customer,
            showtime,
            seat
        );

        Reservations.Add(reservation);
        customer.Reservations.Add(reservation);

        reservationIdCounter++;
    }

    public void ListReservations()
    {
        if (Reservations.Count == 0)
        {
            Console.WriteLine("No reservations registered.");
            return;
        }

        foreach (Reservation reservation in Reservations)
        {
            reservation.DisplayInfo();
        }
    }

    public void ListCustomerReservations(Customer customer)
    {
        if (customer.Reservations.Count == 0)
        {
            Console.WriteLine("You have no reservations.");
            return;
        }

        foreach (Reservation reservation in customer.Reservations)
        {
            reservation.DisplayInfo();
        }
    }

    public void CancelReservation(Customer customer, int reservationId)
    {
        Reservation reservationToRemove = null;

        foreach (Reservation reservation in customer.Reservations)
        {
            if (reservation.Id == reservationId)
            {
                reservationToRemove = reservation;
                break;
            }
        }

        if (reservationToRemove == null)
            throw new Exception("Reservation not found.");

        reservationToRemove.Seat.Cancel();

        customer.Reservations.Remove(reservationToRemove);
        Reservations.Remove(reservationToRemove);
    }

    public void UpdateCounters()
    {
        if (Movies.Count > 0)
        {
            movieIdCounter = Movies[Movies.Count - 1].Id + 1;
        }

        if (Showtimes.Count > 0)
        {
            showtimeIdCounter = Showtimes[Showtimes.Count - 1].Id + 1;
        }

        if (Reservations.Count > 0)
        {
            reservationIdCounter = Reservations[Reservations.Count - 1].Id + 1;
        }
    }
}

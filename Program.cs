CinemaSystem system = FileManager.Load();

if (system.Movies.Count == 0)
{
    system.AddMovie("Interstellar", "Science Fiction", 169);
    system.AddMovie("Ayla", "Drama", 125);

    system.AddHall(1, 10);
    system.AddHall(2, 8);

    system.AddShowtime(1, 1, "14:00");
    system.AddShowtime(2, 2, "18:30");
}

Admin admin = new Admin("Admin", "User", "admin", "1234");

bool isProgramRunning = true;

while (isProgramRunning)
{
    Console.WriteLine("\n=== CINEMA TICKET RESERVATION SYSTEM ===");
    Console.WriteLine("1- Customer Login");
    Console.WriteLine("2- Admin Login");
    Console.WriteLine("0- Exit");
    Console.Write("Your choice: ");

    string choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                EnterCustomerMenu(system);
                break;

            case "2":
                EnterAdminMenu(system, admin);
                break;

            case "0":
                FileManager.Save(system);
                isProgramRunning = false;
                Console.WriteLine("Data saved. Shutting down...");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

static void EnterCustomerMenu(CinemaSystem system)
{
    Console.Write("First name: ");
    string firstName = Console.ReadLine();

    Console.Write("Last name: ");
    string lastName = Console.ReadLine();

    Customer customer = new Customer(firstName, lastName);

    bool isCustomerMenuActive = true;

    while (isCustomerMenuActive)
    {
        Console.WriteLine("\n=== CUSTOMER MENU ===");
        Console.WriteLine("1- List Movies");
        Console.WriteLine("2- List Showtimes");
        Console.WriteLine("3- View Seats");
        Console.WriteLine("4- Make Reservation");
        Console.WriteLine("5- View My Reservations");
        Console.WriteLine("6- Cancel Reservation");
        Console.WriteLine("0- Back");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    system.ListMovies();
                    break;

                case "2":
                    system.ListShowtimes();
                    break;

                case "3":
                    Console.Write("Enter showtime ID: ");
                    int showtimeIdForSeats = Convert.ToInt32(Console.ReadLine());

                    Showtime showtime = system.FindShowtime(showtimeIdForSeats);
                    showtime.Hall.DisplaySeats();
                    break;

                case "4":
                    system.ListShowtimes();

                    Console.Write("Enter showtime ID: ");
                    int showtimeId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter seat number: ");
                    int seatNumber = Convert.ToInt32(Console.ReadLine());

                    system.MakeReservation(customer, showtimeId, seatNumber);
                    Console.WriteLine("Reservation created successfully.");
                    break;

                case "5":
                    system.ListCustomerReservations(customer);
                    break;

                case "6":
                    system.ListCustomerReservations(customer);

                    Console.Write("Enter reservation ID to cancel: ");
                    int reservationId = Convert.ToInt32(Console.ReadLine());

                    system.CancelReservation(customer, reservationId);
                    Console.WriteLine("Reservation cancelled.");
                    break;

                case "0":
                    isCustomerMenuActive = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

static void EnterAdminMenu(CinemaSystem system, Admin admin)
{
    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Write("Password: ");
    string password = Console.ReadLine();

    if (!admin.Login(username, password))
    {
        Console.WriteLine("Invalid username or password.");
        return;
    }

    bool isAdminMenuActive = true;

    while (isAdminMenuActive)
    {
        Console.WriteLine("\n=== ADMIN MENU ===");
        Console.WriteLine("1- Add Movie");
        Console.WriteLine("2- List Movies");
        Console.WriteLine("3- Update Movie");
        Console.WriteLine("4- Delete Movie");
        Console.WriteLine("5- Add Showtime");
        Console.WriteLine("6- List Showtimes");
        Console.WriteLine("7- Update Showtime");
        Console.WriteLine("8- Delete Showtime");
        Console.WriteLine("9- Add Hall");
        Console.WriteLine("10- List Halls");
        Console.WriteLine("11- View All Reservations");
        Console.WriteLine("0- Back");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    Console.Write("Movie name: ");
                    string name = Console.ReadLine();

                    Console.Write("Movie genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Movie duration (minutes): ");
                    int duration = Convert.ToInt32(Console.ReadLine());

                    system.AddMovie(name, genre, duration);
                    Console.WriteLine("Movie added.");
                    break;

                case "2":
                    system.ListMovies();
                    break;

                case "3":
                    system.ListMovies();

                    Console.Write("Movie ID to update: ");
                    int movieId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("New movie name: ");
                    string newName = Console.ReadLine();

                    Console.Write("New movie genre: ");
                    string newGenre = Console.ReadLine();

                    Console.Write("New movie duration (minutes): ");
                    int newDuration = Convert.ToInt32(Console.ReadLine());

                    system.UpdateMovie(movieId, newName, newGenre, newDuration);
                    Console.WriteLine("Movie updated.");
                    break;

                case "4":
                    system.ListMovies();

                    Console.Write("Movie ID to delete: ");
                    int movieIdToDelete = Convert.ToInt32(Console.ReadLine());

                    system.DeleteMovie(movieIdToDelete);
                    Console.WriteLine("Movie deleted.");
                    break;

                case "5":
                    system.ListMovies();
                    system.ListHalls();

                    Console.Write("Movie ID: ");
                    int movieIdForShowtime = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Hall number: ");
                    int hallNumber = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Time: ");
                    string time = Console.ReadLine();

                    system.AddShowtime(movieIdForShowtime, hallNumber, time);
                    Console.WriteLine("Showtime added.");
                    break;

                case "6":
                    system.ListShowtimes();
                    break;

                case "7":
                    system.ListShowtimes();

                    Console.Write("Showtime ID to update: ");
                    int showtimeIdToUpdate = Convert.ToInt32(Console.ReadLine());

                    system.ListMovies();
                    Console.Write("New movie ID: ");
                    int newMovieId = Convert.ToInt32(Console.ReadLine());

                    system.ListHalls();
                    Console.Write("New hall number: ");
                    int newHallNumber = Convert.ToInt32(Console.ReadLine());

                    Console.Write("New time: ");
                    string newTime = Console.ReadLine();

                    system.UpdateShowtime(showtimeIdToUpdate, newMovieId, newHallNumber, newTime);
                    Console.WriteLine("Showtime updated.");
                    break;

                case "8":
                    system.ListShowtimes();

                    Console.Write("Showtime ID to delete: ");
                    int showtimeIdToDelete = Convert.ToInt32(Console.ReadLine());

                    system.DeleteShowtime(showtimeIdToDelete);
                    Console.WriteLine("Showtime deleted.");
                    break;

                case "9":
                    Console.Write("Hall number: ");
                    int newHallNumberForAdd = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Seat count: ");
                    int seatCount = Convert.ToInt32(Console.ReadLine());

                    system.AddHall(newHallNumberForAdd, seatCount);
                    Console.WriteLine("Hall added.");
                    break;

                case "10":
                    system.ListHalls();
                    break;

                case "11":
                    system.ListReservations();
                    break;

                case "0":
                    isAdminMenuActive = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

public class Seans
{
    public int Id { get; private set; }
    public Film Film { get; set; }
    public Salon Salon { get; set; }
    public string Saat { get; set; }

    public Seans(int id, Film film, Salon salon, string saat)
    {
        if (id <= 0)
            throw new ArgumentException("Seans ID 0'dan büyük olmalıdır.");

        Id = id;
        Film = film;
        Salon = salon;
        Saat = saat;
    }

    public void BilgiGoster()
    {
        Console.WriteLine($"Seans ID: {Id} | Film: {Film.Ad} | Salon: {Salon.SalonNo} | Saat: {Saat}");
    }
}
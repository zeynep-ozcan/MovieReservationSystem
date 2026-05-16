public class Rezervasyon
{
    public int Id { get; private set; }
    public Musteri Musteri { get; set; }
    public Seans Seans { get; set; }
    public Koltuk Koltuk { get; set; }

    public Rezervasyon(int id, Musteri musteri, Seans seans, Koltuk koltuk)
    {
        if (id <= 0)
            throw new ArgumentException("Rezervasyon ID 0'dan büyük olmalıdır.");

        Id = id;
        Musteri = musteri;
        Seans = seans;
        Koltuk = koltuk;
    }

    public void BilgiGoster()
    {
        Console.WriteLine(
            $"Rezervasyon ID: {Id} | " +
            $"Müşteri: {Musteri.Ad} {Musteri.Soyad} | " +
            $"Film: {Seans.Film.Ad} | " +
            $"Salon: {Seans.Salon.SalonNo} | " +
            $"Koltuk: {Koltuk.KoltukNo} | " +
            $"Saat: {Seans.Saat}"
        );
    }
}
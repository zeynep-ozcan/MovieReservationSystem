public class Musteri : Kisi
{
    public List<Rezervasyon> Rezervasyonlar { get; set; }

    public Musteri(string ad, string soyad) : base(ad, soyad)
    {
        Rezervasyonlar = new List<Rezervasyon>();
    }

    public override void BilgiGoster()
    {
        Console.WriteLine($"Müşteri: {Ad} {Soyad}");
    }
}
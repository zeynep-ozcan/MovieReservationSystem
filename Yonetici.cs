public class Yonetici : Kisi
{
    public string KullaniciAdi { get; private set; }
    public string Sifre { get; private set; }

    public Yonetici(string ad, string soyad, string kullaniciAdi, string sifre)
        : base(ad, soyad)
    {
        KullaniciAdi = kullaniciAdi;
        Sifre = sifre;
    }

    public bool GirisYap(string kullaniciAdi, string sifre)
    {
        return KullaniciAdi == kullaniciAdi && Sifre == sifre;
    }

    public override void BilgiGoster()
    {
        Console.WriteLine($"Yönetici: {Ad} {Soyad}");
    }
}
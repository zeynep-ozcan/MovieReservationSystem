public abstract class Kisi
{
    public string Ad { get; set; }
    public string Soyad { get; set; }

    public Kisi(string ad, string soyad)
    {
        Ad = ad;
        Soyad = soyad;
    }

    public abstract void BilgiGoster();
}
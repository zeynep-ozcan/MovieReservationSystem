public class Film
{
    public int Id { get; private set; }
    public string Ad { get; set; }
    public string Tur { get; set; }
    public int Sure { get; set; }

    public Film(int id, string ad, string tur, int sure)
    {
        if (id <= 0)
            throw new ArgumentException("Film ID 0'dan büyük olmalıdır.");

        if (sure <= 0)
            throw new ArgumentException("Film süresi 0'dan büyük olmalıdır.");

        Id = id;
        Ad = ad;
        Tur = tur;
        Sure = sure;
    }

    public void BilgiGoster()
    {
        Console.WriteLine($"ID: {Id} | Film: {Ad} | Tür: {Tur} | Süre: {Sure} dk");
    }
}
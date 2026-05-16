public class Salon
{
    public int SalonNo { get; private set; }
    public List<Koltuk> Koltuklar { get; private set; }

    public Salon(int salonNo, int koltukSayisi)
    {
        if (salonNo <= 0)
            throw new ArgumentException("Salon numarası 0'dan büyük olmalıdır.");

        if (koltukSayisi <= 0)
            throw new ArgumentException("Koltuk sayısı 0'dan büyük olmalıdır.");

        SalonNo = salonNo;
        Koltuklar = new List<Koltuk>();

        for (int i = 1; i <= koltukSayisi; i++)
        {
            Koltuklar.Add(new Koltuk(i));
        }
    }

    public void KoltuklariGoster()
    {
        Console.WriteLine($"\nSalon {SalonNo} Koltuk Durumu:");

        foreach (Koltuk koltuk in Koltuklar)
        {
            string durum = koltuk.DoluMu ? "Dolu" : "Boş";
            Console.WriteLine($"Koltuk {koltuk.KoltukNo}: {durum}");
        }
    }

    public Koltuk KoltukBul(int koltukNo)
    {
        foreach (Koltuk koltuk in Koltuklar)
        {
            if (koltuk.KoltukNo == koltukNo)
                return koltuk;
        }

        throw new Exception("Koltuk bulunamadı.");
    }
}
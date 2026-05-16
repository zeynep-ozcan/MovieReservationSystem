public class DosyaYonetimi
{
    private static string filmDosyasi = "filmler.txt";
    private static string salonDosyasi = "salonlar.txt";
    private static string seansDosyasi = "seanslar.txt";
    private static string rezervasyonDosyasi = "rezervasyonlar.txt";

    public static void Kaydet(SinemaSistemi sistem)
    {
        using (StreamWriter filmYazici = new StreamWriter(filmDosyasi))
        {
            foreach (Film film in sistem.Filmler)
            {
                filmYazici.WriteLine($"{film.Ad};{film.Tur};{film.Sure}");
            }
        }

        using (StreamWriter salonYazici = new StreamWriter(salonDosyasi))
        {
            foreach (Salon salon in sistem.Salonlar)
            {
                salonYazici.WriteLine($"{salon.SalonNo};{salon.Koltuklar.Count}");
            }
        }

        using (StreamWriter seansYazici = new StreamWriter(seansDosyasi))
        {
            foreach (Seans seans in sistem.Seanslar)
            {
                seansYazici.WriteLine($"{seans.Film.Id};{seans.Salon.SalonNo};{seans.Saat}");
            }
        }

        using (StreamWriter rezervasyonYazici = new StreamWriter(rezervasyonDosyasi))
        {
            foreach (Rezervasyon rezervasyon in sistem.Rezervasyonlar)
            {
                rezervasyonYazici.WriteLine(
                    $"{rezervasyon.Musteri.Ad};{rezervasyon.Musteri.Soyad};{rezervasyon.Seans.Id};{rezervasyon.Koltuk.KoltukNo}"
                );
            }
        }
    }

    public static SinemaSistemi Yukle()
    {
        SinemaSistemi sistem = new SinemaSistemi();

        if (File.Exists(filmDosyasi))
        {
            foreach (string satir in File.ReadAllLines(filmDosyasi))
            {
                string[] parcalar = satir.Split(';');

                if (parcalar.Length == 3)
                {
                    sistem.FilmEkle(
                        parcalar[0],
                        parcalar[1],
                        Convert.ToInt32(parcalar[2])
                    );
                }
            }
        }

        if (File.Exists(salonDosyasi))
        {
            foreach (string satir in File.ReadAllLines(salonDosyasi))
            {
                string[] parcalar = satir.Split(';');

                if (parcalar.Length == 2)
                {
                    sistem.SalonEkle(
                        Convert.ToInt32(parcalar[0]),
                        Convert.ToInt32(parcalar[1])
                    );
                }
            }
        }

        if (File.Exists(seansDosyasi))
        {
            foreach (string satir in File.ReadAllLines(seansDosyasi))
            {
                string[] parcalar = satir.Split(';');

                if (parcalar.Length == 3)
                {
                    sistem.SeansEkle(
                        Convert.ToInt32(parcalar[0]),
                        Convert.ToInt32(parcalar[1]),
                        parcalar[2]
                    );
                }
            }
        }

        if (File.Exists(rezervasyonDosyasi))
        {
            foreach (string satir in File.ReadAllLines(rezervasyonDosyasi))
            {
                string[] parcalar = satir.Split(';');

                if (parcalar.Length == 4)
                {
                    string musteriAd = parcalar[0];
                    string musteriSoyad = parcalar[1];
                    int seansId = Convert.ToInt32(parcalar[2]);
                    int koltukNo = Convert.ToInt32(parcalar[3]);

                    Musteri musteri = new Musteri(musteriAd, musteriSoyad);

                    try
                    {
                        sistem.RezervasyonYap(musteri, seansId, koltukNo);
                    }
                    catch
                    {
                       
                    }
                }
            }
        }

        return sistem;
    }
}
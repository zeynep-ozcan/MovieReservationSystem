public class SinemaSistemi
{
    public List<Film> Filmler { get; set; }
public List<Salon> Salonlar { get; set; }
public List<Seans> Seanslar { get; set; }
public List<Rezervasyon> Rezervasyonlar { get; set; }

    private int filmIdSayac = 1;
    private int seansIdSayac = 1;
    private int rezervasyonIdSayac = 1;

    public SinemaSistemi()
    {
        Filmler = new List<Film>();
        Salonlar = new List<Salon>();
        Seanslar = new List<Seans>();
        Rezervasyonlar = new List<Rezervasyon>();
    }

    // Film CRUD

    public void FilmEkle(string ad, string tur, int sure)
    {
        Film film = new Film(filmIdSayac, ad, tur, sure);
        Filmler.Add(film);
        filmIdSayac++;
    }

    public void FilmleriListele()
    {
        if (Filmler.Count == 0)
        {
            Console.WriteLine("Kayıtlı film yok.");
            return;
        }

        foreach (Film film in Filmler)
        {
            film.BilgiGoster();
        }
    }

    public Film FilmBul(int id)
    {
        foreach (Film film in Filmler)
        {
            if (film.Id == id)
                return film;
        }

        throw new Exception("Film bulunamadı.");
    }

    public void FilmGuncelle(int id, string yeniAd, string yeniTur, int yeniSure)
    {
        Film film = FilmBul(id);

        if (yeniSure <= 0)
            throw new ArgumentException("Film süresi 0'dan büyük olmalıdır.");

        film.Ad = yeniAd;
        film.Tur = yeniTur;
        film.Sure = yeniSure;
    }

    public void FilmSil(int id)
    {
        Film film = FilmBul(id);
        Filmler.Remove(film);
    }

    // Salon işlemleri

    public void SalonEkle(int salonNo, int koltukSayisi)
    {
        Salon salon = new Salon(salonNo, koltukSayisi);
        Salonlar.Add(salon);
    }

    public void SalonlariListele()
    {
        if (Salonlar.Count == 0)
        {
            Console.WriteLine("Kayıtlı salon yok.");
            return;
        }

        foreach (Salon salon in Salonlar)
        {
            Console.WriteLine($"Salon No: {salon.SalonNo} | Koltuk Sayısı: {salon.Koltuklar.Count}");
        }
    }

    public Salon SalonBul(int salonNo)
    {
        foreach (Salon salon in Salonlar)
        {
            if (salon.SalonNo == salonNo)
                return salon;
        }

        throw new Exception("Salon bulunamadı.");
    }

    // Seans CRUD

    public void SeansEkle(int filmId, int salonNo, string saat)
    {
        Film film = FilmBul(filmId);
        Salon salon = SalonBul(salonNo);

        Seans seans = new Seans(seansIdSayac, film, salon, saat);
        Seanslar.Add(seans);
        seansIdSayac++;
    }

    public void SeanslariListele()
    {
        if (Seanslar.Count == 0)
        {
            Console.WriteLine("Kayıtlı seans yok.");
            return;
        }

        foreach (Seans seans in Seanslar)
        {
            seans.BilgiGoster();
        }
    }

    public Seans SeansBul(int id)
    {
        foreach (Seans seans in Seanslar)
        {
            if (seans.Id == id)
                return seans;
        }

        throw new Exception("Seans bulunamadı.");
    }

    public void SeansGuncelle(int id, int yeniFilmId, int yeniSalonNo, string yeniSaat)
    {
        Seans seans = SeansBul(id);
        Film film = FilmBul(yeniFilmId);
        Salon salon = SalonBul(yeniSalonNo);

        seans.Film = film;
        seans.Salon = salon;
        seans.Saat = yeniSaat;
    }

    public void SeansSil(int id)
    {
        Seans seans = SeansBul(id);
        Seanslar.Remove(seans);
    }

    // Rezervasyon işlemleri

    public void RezervasyonYap(Musteri musteri, int seansId, int koltukNo)
    {
        Seans seans = SeansBul(seansId);
        Koltuk koltuk = seans.Salon.KoltukBul(koltukNo);

        koltuk.RezerveEt();

        Rezervasyon rezervasyon = new Rezervasyon(
            rezervasyonIdSayac,
            musteri,
            seans,
            koltuk
        );

        Rezervasyonlar.Add(rezervasyon);
        musteri.Rezervasyonlar.Add(rezervasyon);

        rezervasyonIdSayac++;
    }

    public void RezervasyonlariListele()
    {
        if (Rezervasyonlar.Count == 0)
        {
            Console.WriteLine("Kayıtlı rezervasyon yok.");
            return;
        }

        foreach (Rezervasyon rezervasyon in Rezervasyonlar)
        {
            rezervasyon.BilgiGoster();
        }
    }

    public void MusteriRezervasyonlariniListele(Musteri musteri)
    {
        if (musteri.Rezervasyonlar.Count == 0)
        {
            Console.WriteLine("Rezervasyonunuz yok.");
            return;
        }

        foreach (Rezervasyon rezervasyon in musteri.Rezervasyonlar)
        {
            rezervasyon.BilgiGoster();
        }
    }

    public void RezervasyonIptalEt(Musteri musteri, int rezervasyonId)
    {
        Rezervasyon silinecekRezervasyon = null;

        foreach (Rezervasyon rezervasyon in musteri.Rezervasyonlar)
        {
            if (rezervasyon.Id == rezervasyonId)
            {
                silinecekRezervasyon = rezervasyon;
                break;
            }
        }

        if (silinecekRezervasyon == null)
            throw new Exception("Rezervasyon bulunamadı.");

        silinecekRezervasyon.Koltuk.IptalEt();

        musteri.Rezervasyonlar.Remove(silinecekRezervasyon);
        Rezervasyonlar.Remove(silinecekRezervasyon);
    }
}
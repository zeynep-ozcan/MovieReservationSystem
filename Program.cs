SinemaSistemi sistem = DosyaYonetimi.Yukle();

if (sistem.Filmler.Count == 0)
{
    sistem.FilmEkle("Interstellar", "Bilim Kurgu", 169);
    sistem.FilmEkle("Ayla", "Dram", 125);

    sistem.SalonEkle(1, 10);
    sistem.SalonEkle(2, 8);

    sistem.SeansEkle(1, 1, "14:00");
    sistem.SeansEkle(2, 2, "18:30");
}

Yonetici yonetici = new Yonetici("Admin", "User", "admin", "1234");

bool programCalisiyor = true;

while (programCalisiyor)
{
    Console.WriteLine("\n=== SİNEMA BİLET REZERVASYON SİSTEMİ ===");
    Console.WriteLine("1- Müşteri Girişi");
    Console.WriteLine("2- Yönetici Girişi");
    Console.WriteLine("0- Çıkış");
    Console.Write("Seçiminiz: ");

    string secim = Console.ReadLine();

    try
    {
        switch (secim)
        {
            case "1":
                MusteriGirisi(sistem);
                break;

            case "2":
                YoneticiGirisi(sistem, yonetici);
                break;

            case "0":
    DosyaYonetimi.Kaydet(sistem);
    programCalisiyor = false;
    Console.WriteLine("Veriler kaydedildi. Program kapatılıyor...");
    break;

            default:
                Console.WriteLine("Geçersiz seçim.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Hata: " + ex.Message);
    }
}

static void MusteriGirisi(SinemaSistemi sistem)
{
    Console.Write("Adınız: ");
    string ad = Console.ReadLine();

    Console.Write("Soyadınız: ");
    string soyad = Console.ReadLine();

    Musteri musteri = new Musteri(ad, soyad);

    bool musteriMenu = true;

    while (musteriMenu)
    {
        Console.WriteLine("\n=== MÜŞTERİ MENÜSÜ ===");
        Console.WriteLine("1- Filmleri Listele");
        Console.WriteLine("2- Seansları Listele");
        Console.WriteLine("3- Koltukları Görüntüle");
        Console.WriteLine("4- Rezervasyon Yap");
        Console.WriteLine("5- Rezervasyonlarımı Görüntüle");
        Console.WriteLine("6- Rezervasyon İptal Et");
        Console.WriteLine("0- Geri Dön");
        Console.Write("Seçiminiz: ");

        string secim = Console.ReadLine();

        try
        {
            switch (secim)
            {
                case "1":
                    sistem.FilmleriListele();
                    break;

                case "2":
                    sistem.SeanslariListele();
                    break;

                case "3":
                    Console.Write("Seans ID giriniz: ");
                    int seansIdKoltuk = Convert.ToInt32(Console.ReadLine());

                    Seans seans = sistem.SeansBul(seansIdKoltuk);
                    seans.Salon.KoltuklariGoster();
                    break;

                case "4":
                    sistem.SeanslariListele();

                    Console.Write("Seans ID giriniz: ");
                    int seansId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Koltuk No giriniz: ");
                    int koltukNo = Convert.ToInt32(Console.ReadLine());

                    sistem.RezervasyonYap(musteri, seansId, koltukNo);
                    Console.WriteLine("Rezervasyon başarıyla oluşturuldu.");
                    break;

                case "5":
                    sistem.MusteriRezervasyonlariniListele(musteri);
                    break;

                case "6":
                    sistem.MusteriRezervasyonlariniListele(musteri);

                    Console.Write("İptal edilecek rezervasyon ID: ");
                    int rezervasyonId = Convert.ToInt32(Console.ReadLine());

                    sistem.RezervasyonIptalEt(musteri, rezervasyonId);
                    Console.WriteLine("Rezervasyon iptal edildi.");
                    break;

                case "0":
                    musteriMenu = false;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }
}

static void YoneticiGirisi(SinemaSistemi sistem, Yonetici yonetici)
{
    Console.Write("Kullanıcı adı: ");
    string kullaniciAdi = Console.ReadLine();

    Console.Write("Şifre: ");
    string sifre = Console.ReadLine();

    if (!yonetici.GirisYap(kullaniciAdi, sifre))
    {
        Console.WriteLine("Hatalı kullanıcı adı veya şifre.");
        return;
    }

    bool yoneticiMenu = true;

    while (yoneticiMenu)
    {
        Console.WriteLine("\n=== YÖNETİCİ MENÜSÜ ===");
        Console.WriteLine("1- Film Ekle");
        Console.WriteLine("2- Film Listele");
        Console.WriteLine("3- Film Güncelle");
        Console.WriteLine("4- Film Sil");
        Console.WriteLine("5- Seans Ekle");
        Console.WriteLine("6- Seans Listele");
        Console.WriteLine("7- Seans Güncelle");
        Console.WriteLine("8- Seans Sil");
        Console.WriteLine("9- Salon Ekle");
        Console.WriteLine("10- Salon Listele");
        Console.WriteLine("11- Tüm Rezervasyonları Görüntüle");
        Console.WriteLine("0- Geri Dön");
        Console.Write("Seçiminiz: ");

        string secim = Console.ReadLine();

        try
        {
            switch (secim)
            {
                case "1":
                    Console.Write("Film adı: ");
                    string ad = Console.ReadLine();

                    Console.Write("Film türü: ");
                    string tur = Console.ReadLine();

                    Console.Write("Film süresi: ");
                    int sure = Convert.ToInt32(Console.ReadLine());

                    sistem.FilmEkle(ad, tur, sure);
                    Console.WriteLine("Film eklendi.");
                    break;

                case "2":
                    sistem.FilmleriListele();
                    break;

                case "3":
                    sistem.FilmleriListele();

                    Console.Write("Güncellenecek film ID: ");
                    int filmId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Yeni film adı: ");
                    string yeniAd = Console.ReadLine();

                    Console.Write("Yeni film türü: ");
                    string yeniTur = Console.ReadLine();

                    Console.Write("Yeni film süresi: ");
                    int yeniSure = Convert.ToInt32(Console.ReadLine());

                    sistem.FilmGuncelle(filmId, yeniAd, yeniTur, yeniSure);
                    Console.WriteLine("Film güncellendi.");
                    break;

                case "4":
                    sistem.FilmleriListele();

                    Console.Write("Silinecek film ID: ");
                    int silinecekFilmId = Convert.ToInt32(Console.ReadLine());

                    sistem.FilmSil(silinecekFilmId);
                    Console.WriteLine("Film silindi.");
                    break;

                case "5":
                    sistem.FilmleriListele();
                    sistem.SalonlariListele();

                    Console.Write("Film ID: ");
                    int seansFilmId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Salon No: ");
                    int salonNo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Saat: ");
                    string saat = Console.ReadLine();

                    sistem.SeansEkle(seansFilmId, salonNo, saat);
                    Console.WriteLine("Seans eklendi.");
                    break;

                case "6":
                    sistem.SeanslariListele();
                    break;

                case "7":
                    sistem.SeanslariListele();

                    Console.Write("Güncellenecek seans ID: ");
                    int guncellenecekSeansId = Convert.ToInt32(Console.ReadLine());

                    sistem.FilmleriListele();
                    Console.Write("Yeni film ID: ");
                    int yeniFilmId = Convert.ToInt32(Console.ReadLine());

                    sistem.SalonlariListele();
                    Console.Write("Yeni salon no: ");
                    int yeniSalonNo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Yeni saat: ");
                    string yeniSaat = Console.ReadLine();

                    sistem.SeansGuncelle(guncellenecekSeansId, yeniFilmId, yeniSalonNo, yeniSaat);
                    Console.WriteLine("Seans güncellendi.");
                    break;

                case "8":
                    sistem.SeanslariListele();

                    Console.Write("Silinecek seans ID: ");
                    int silinecekSeansId = Convert.ToInt32(Console.ReadLine());

                    sistem.SeansSil(silinecekSeansId);
                    Console.WriteLine("Seans silindi.");
                    break;

                case "9":
                    Console.Write("Salon No: ");
                    int yeniSalonNumarasi = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Koltuk sayısı: ");
                    int koltukSayisi = Convert.ToInt32(Console.ReadLine());

                    sistem.SalonEkle(yeniSalonNumarasi, koltukSayisi);
                    Console.WriteLine("Salon eklendi.");
                    break;

                case "10":
                    sistem.SalonlariListele();
                    break;

                case "11":
                    sistem.RezervasyonlariListele();
                    break;

                case "0":
                    yoneticiMenu = false;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }
}

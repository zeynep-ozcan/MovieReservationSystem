public class Koltuk
{
    public int KoltukNo { get; private set; }
    public bool DoluMu { get; private set; }

    public Koltuk(int koltukNo)
    {
        if (koltukNo <= 0)
            throw new ArgumentException("Koltuk numarası 0'dan büyük olmalıdır.");

        KoltukNo = koltukNo;
        DoluMu = false;
    }

    public void RezerveEt()
    {
        if (DoluMu)
            throw new Exception("Bu koltuk zaten dolu.");

        DoluMu = true;
    }

    public void IptalEt()
    {
        if (!DoluMu)
            throw new Exception("Bu koltuk zaten boş.");

        DoluMu = false;
    }
}
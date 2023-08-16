public class Pallet : StorageItem
{
    private static readonly Random random = new Random();
    private static readonly HashSet<string> UsedIDs = new HashSet<string>();
    private readonly string v;

    public List<Box> Boxes { get; } = new List<Box>();
    public string ID { get; private set; } = GenerateUniqueID();
    public double PalletWidth { get; } = 800;
    public double PalletLength { get; } = 1200;
    public double PalletHeight { get; } = 144;

    public Pallet(string v) : base(30.0)
    {
    }

    public double GetVolumePallet()
    {
        double volumeAllBoxes = Boxes.Sum(box => box.GetVolumeBox());
        return PalletWidth * PalletLength * PalletHeight + volumeAllBoxes;
    }

    public DateTime GetMinShelfLife()
    {
        return Boxes.Min(box => box.ExpirationDate);
    }

    public DateTime GetMaxShelfLife()
    {
        return Boxes.Max(box => box.ExpirationDate);
    }

    public double GetTotalValue()
    {
        double totalValue = GetVolumePallet() + Boxes.Sum(box => box.GetVolumeBox());
        return totalValue;
    }

    public double TotalWeight()
    {
        double total = Weight + Boxes.Sum(box => box.Weight);
        return total;
    }

    private static string GenerateRandomString(int length, string characterSet)
    {
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = characterSet[random.Next(characterSet.Length)];
        }
        return new string(result);
    }

    private static bool IsIDUnique(string id)
    {
        return !UsedIDs.Contains(id);
    }

    public static string GenerateUniqueID()
    {
        string id;

        do
        {
            id = GenerateRandomString(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + GenerateRandomString(5, "0123456789");
        } while (!IsIDUnique(id));

        UsedIDs.Add(id);
        return id;
    }

    public List<Box> GetExpiredBoxes()
    {
        DateTime currentDate = DateTime.Now.Date;
        List<Box> expiredBoxes = Boxes.Where(box => box.ExpirationDate < currentDate).ToList();
        return expiredBoxes;
    }

    public void RemoveBox(Box box)
    {
        if (Boxes.Contains(box))
        {
            Boxes.Remove(box);
        }
    }
}

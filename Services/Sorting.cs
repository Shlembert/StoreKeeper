public static class Sorting
{
    public static void DeleteExpiredBoxes(List<Pallet> pallets, int palletIndex)
    {
        var pallet = pallets[palletIndex - 1];
        var expiredBoxes = pallet.GetExpiredBoxes();

        pallet.Boxes.RemoveAll(box => expiredBoxes.Contains(box));

        Console.WriteLine("\nПросроченные коробки удалены с паллеты.");
        DataStorage.Save(palletIndex + 1);
        BoxMenu.ShowBoxes(pallets[palletIndex], palletIndex);
    }

    public static void Sort(List<Pallet> pallets)
    {
        pallets.Sort(ComparePallets);
    }

    private static int ComparePallets(Pallet p1, Pallet p2)
    {
        int compare = p1.GetMinShelfLife().CompareTo(p2.GetMinShelfLife());

        if (compare == 0)
        {
            return p1.TotalWeight().CompareTo(p2.TotalWeight());
        }
        else
        {
            return compare;
        }
    }

    public static List<Pallet> GetTopThreePalletsVolume(List<Pallet> pallets)
    {
        var topThreePallets = pallets.OrderBy(p => p.GetMaxShelfLife())
                                     .Take(3)
                                     .OrderByDescending(p => p.GetTotalValue())
                                     .ToList();
        return topThreePallets;
    }
}

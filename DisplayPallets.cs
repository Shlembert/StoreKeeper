public class DisplayPallets
{
    public static void ShowPallets(List<Pallet> pallets)
    {
        Console.WriteLine("\nСписок паллет:\n");
        Console.WriteLine("Номер  ID       Кол-во кор.   Срок годн.    Коробки(кг)    Объем кор.    Объем пал.   Вес пал. с кор.(кг) ");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------");

        for (int i = 0; i < pallets.Count; i++)
        {
            var pallet = pallets[i];

            Console.Write($"{i + 1,-7}");
            Console.Write($"{pallet.ID,-14}");
            Console.Write($"{pallet.Boxes.Count,-9}");

            DateTime minExpirationDate = pallet.GetMinShelfLife();
            Console.Write($"{minExpirationDate.ToString("dd.MM.yy"),-16}");

            double totalBoxWeight = pallet.Boxes.Sum(box => box.Weight);
            Console.Write($"{totalBoxWeight,-15:F1}");

            double totalBoxVolumeCm = pallet.Boxes.Sum(box => box.GetVolumeBox());
            double totalBoxVolumeM = totalBoxVolumeCm / 1000000.0;
            Console.Write($"{totalBoxVolumeM,-14:F3}");

            double palletVolumeCm = pallet.GetVolumePallet();
            double palletVolumeM = palletVolumeCm / 1000000.0;
            Console.Write($"{palletVolumeM,-18:F3}");

            double palletWeightWithBoxes = totalBoxWeight + pallet.Weight;
            Console.WriteLine($"{palletWeightWithBoxes,-20:F1}");
        }

        Console.WriteLine();
    }
}


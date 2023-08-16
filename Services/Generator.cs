public class Generator
{
    public static List<Pallet> GeneratePallets(int boxCount)
    {
        List<Pallet> pallets = new List<Pallet>(); // Список паллет
        Pallet? currentPallet = null; // Текущая паллета

        Random random = new Random();
        currentPallet = new Pallet(Pallet.GenerateUniqueID());
        pallets.Add(currentPallet); // Добавление паллеты в список

        for (int i = 0; i < boxCount; i++)
        {
            double width = random.NextDouble() * 60 + 10; // Случайная ширина коробки от 1 до 11
            double height = random.NextDouble() * 60 + 10; // Случайная ширина коробки от 1 до 11
            double length = random.NextDouble() * 80 + 10; // Случайная длина коробки от 1 до 11
            double weight = random.NextDouble() * 10 + 10; // Случайный вес коробки от 1 до 21
            DateTime productionDate = DateTime.Now.AddDays(-random.Next(120)); // Случайная дата производства в пределах квартала
           
            var box = new Box(i,width,length,height, weight,productionDate);
            if(currentPallet.Weight > box.Weight && currentPallet.PalletLength > box.Length)
            {
                currentPallet.Boxes.Add(box);
            }
            else
            {
                // Вынести со склада, это не коробка!
            }
        }

        return pallets; // Возвращение списка паллет
    }
}


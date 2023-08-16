public class GeneratorMenu
{
    public static void GenerateBoxes()
    {
        Console.Write("Введите количество генерируемых коробок: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int count) && count > 0)
        {
            Program.Pallets = Generator.GeneratePallets(count);
            var pallets = Program.Pallets;

            Console.WriteLine($"\nСгенерировано паллет: {pallets.Count}\n");

            Program.CurrentMenuType = Program.MenuType.PalletMenu;
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное целое число для количества коробок.");
        }
    }
}
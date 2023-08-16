public class BoxMenu
{
    public static void Show()
    {
        Console.Write("Введите номер паллеты, чтобы показать коробки: ");
        string? input = Console.ReadLine();
        var pallets = Program.Pallets;

        if (int.TryParse(input, out int palletIndex) && palletIndex <= pallets.Count)
        {
            var pallet = pallets[palletIndex - 1];
            ShowBoxes(pallet, palletIndex - 1);
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите допустимый номер паллеты.");
        }
    }

    public static void ShowBoxes(Pallet pallet, int palletIndex)
    {
        Console.WriteLine($"Паллета {palletIndex + 1}: id: {pallet.ID}");
        Console.WriteLine($"Количество коробок: {pallet.Boxes.Count}");

        Console.WriteLine("\nТаблица коробок:\n");
        Console.WriteLine("Ряд   ID коробки     Вес коробки (кг)   Срок годности");
        Console.WriteLine("-----------------------------------------------------");

        foreach (var box in pallet.Boxes)
        {
            Console.Write("      ");
            Console.Write($"{box.ID,-14}");
            Console.Write($"{box.Weight,-19:F3}");
            Console.WriteLine($"{box.GetExpirationStatus()}");
        }

        Console.WriteLine();
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("\n1. Вернуться в меню");
        Console.WriteLine("2. Выбрать другую паллету");

        Console.Write("\nВведите ваш выбор: ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                // Вернуться в меню
                Program.CurrentMenuType = Program.MenuType.MainMenu;
                return;
            case "2":
                // Выбрать другую паллету
                DisplayPallets.ShowPallets(Program.Pallets);
                Show();
                Program.CurrentMenuType = Program.MenuType.PalletMenu;
                break;
            default:
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите действие из списка.");

                break;
        }
    }
}



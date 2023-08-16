public static class PalletMenu
{
    public static void ShowMenu()
    {
        DisplayPallets.ShowPallets(Program.Pallets);

        Console.WriteLine("\nПожалуйста, выберите действие:");
        Console.WriteLine("1. Вернуться в меню");
        Console.WriteLine("2. Сортировать паллеты");
        Console.WriteLine("3. Показать коробки");
        Console.WriteLine("4. Сохранить");
        Console.Write("\nВведите ваш выбор: ");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                // Вернуться в меню
                Program.CurrentMenuType = Program.MenuType.MainMenu;
                break;
            case "2":
                // Сортировка
                Program.CurrentMenuType = Program.MenuType.SortingMenu;
                break;
            case "3":
                // Показать коробки
                Program.CurrentMenuType= Program.MenuType.BoxMenu;
                break;
            case "4":
                // Показать меню файлы
                Program.CurrentMenuType = Program.MenuType.FileMenu;
                break;
            default:
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите пункт из меню.");
                break;
        }
    }
}


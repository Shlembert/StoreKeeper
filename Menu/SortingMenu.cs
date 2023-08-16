public static class SortingMenu
{
    public static void Show()
    {
        DisplayPallets.ShowPallets(Program.Pallets);
        Console.WriteLine();
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("\n1. Вернуться в меню");
        Console.WriteLine("2. Сгруппировать все паллеты по сроку годности");
        Console.WriteLine("3. Вывести топ 3 паллеты по возрастанию объема");
        Console.WriteLine("4. Сохранить ");  
        Console.Write("\nВведите ваш выбор: ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                // Вернуться в меню
                Program.CurrentMenuType = Program.MenuType.MainMenu;
                break;
            case "2":
                Sorting.Sort(Program.Pallets);
                break;
            case "3":
                DisplayPallets.ShowPallets(Sorting.GetTopThreePalletsVolume(Program.Pallets));
                break;
            case "4":
                Program.CurrentMenuType = Program.MenuType.FileMenu;
                break;
            default:
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите действие из списка.");
                break;
        }
    }
}

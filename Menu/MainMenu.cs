public static class MainMenu
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("\nПожалуйста, выберите действие:");
        Console.WriteLine("1. Сгенерировать коробки");
        Console.WriteLine("2. Загрузить из файла");
        Console.WriteLine("3. Ввести в ручную");
        Console.WriteLine("4. Выход");

        Console.Write("\nВведите ваш выбор: ");

        string? choice = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(choice))
        {
            switch (choice)
            {
                case "1":
                    Program.CurrentMenuType = Program.MenuType.GeneratorMenu;
                    break;
                case "2":
                    Program.CurrentMenuType = Program.MenuType.LoadingMenu;
                    break;
                case "3":
                    // EnterManually();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}
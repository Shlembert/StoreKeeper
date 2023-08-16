using Newtonsoft.Json;

public static class LoadMenu
{
    public static void Show()
    {
        FileMenu.ShowAllFiles();
        Console.Write("\nВведите номер файла: ");

        string[] files = FileHandler.GetFiles(DataStorage.DataFolderPath);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int fileIndex) && fileIndex > 0)
        {
            if (fileIndex <= files.Length)
            {
                string filePath = files[fileIndex - 1];
                string jsonData = FileHandler.ReadFile(filePath);
                Program.Pallets = JsonConvert.DeserializeObject<List<Pallet>>(jsonData);
                
                PalletMenu.ShowMenu();
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите допустимый номер файла.");
                Program.CurrentMenuType = Program.MenuType.MainMenu;
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, выберите допустимый номер файла.");
            Program.CurrentMenuType = Program.MenuType.MainMenu;
        }
    }
}


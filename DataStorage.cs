using Newtonsoft.Json;

public class DataStorage
{
    public const string DataFolderPath = "Data";

    public static void CheckFolderPath()
    {
        if (!Directory.Exists(DataFolderPath))
        {
            Directory.CreateDirectory(DataFolderPath);
        }

        FileMenu.ShowAllFiles();
        FileMenu.Show();
    }

    public static void CreateNewFile(string fileNameInput)
    {
        string newFilePath = Path.Combine(DataFolderPath, $"{fileNameInput}.json");
        string newJsonData = JsonConvert.SerializeObject(Program.Pallets);
        FileHandler.WriteFile(newFilePath, newJsonData);
    }

    public static void Save(int fileIndex)
   {
        var pallets = Program.Pallets;
        string[] files = FileHandler.GetFiles(DataFolderPath);

        if (fileIndex > 0 && fileIndex <= files.Length)
        {
            string filePath = files[fileIndex - 1];
            string jsonData = FileHandler.ReadFile(filePath);
            List<Pallet> palletsFromFile = JsonConvert.DeserializeObject<List<Pallet>>(jsonData);

            foreach (var pallet in pallets)
            {
                int index = palletsFromFile.FindIndex(p => p.ID == pallet.ID);

                if (index >= 0)
                {
                    palletsFromFile[index] = pallet;
                }
                else
                {
                    palletsFromFile.Add(pallet);
                }
            }

            string updatedJsonData = JsonConvert.SerializeObject(palletsFromFile);
            FileHandler.WriteFile(filePath, updatedJsonData);
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, выберите допустимый номер файла.");
        }
    }


    public static void DeletePalletFromFile(string fileName, Pallet pallet)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("Неверное имя файла.");
            return;
        }

        string filePath = Path.Combine(DataFolderPath, $"{fileName}.json");

        if (!FileHandler.FileExists(filePath))
        {
            Console.WriteLine("Файл не существует.");
            return;
        }

        string jsonData = FileHandler.ReadFile(filePath);
        List<Pallet> existingPallets = JsonConvert.DeserializeObject<List<Pallet>>(jsonData);

        if (existingPallets == null)
        {
            Console.WriteLine("Паллеты не найдены в файле.");
            return;
        }

        Pallet palletToRemove = existingPallets.Find(p => p.ID == pallet.ID);

        if (palletToRemove != null)
        {
            existingPallets.Remove(palletToRemove);
            string updatedJsonData = JsonConvert.SerializeObject(existingPallets);
            FileHandler.WriteFile(filePath, updatedJsonData);
            Console.WriteLine("Паллета успешно удалена из файла.");
        }
        else
        {
            Console.WriteLine("Паллета не найдена в файле.");
        }
    }
}

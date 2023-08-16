public class FileMenu
{
    public static void Show()
    {
        Console.WriteLine();
        Console.WriteLine("Выберите действие для сохранения:");
        Console.WriteLine();
        Console.WriteLine("1. Сохранить в файл");
        Console.WriteLine("2. Создать новый файл");
        Console.WriteLine("3. Удалить файл");
        Console.WriteLine("4. Назад");
        Console.WriteLine();
        Console.Write("Введите ваш выбор: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                WriteToExistingFile();
                break;
            case "2":
                ShowCreateNewFile();
                break;
            case "3":
                DeleteFile();
                break;
            case "4":
                Program.CurrentMenuType = Program.MenuType.MainMenu;
                break;
            default:
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите действие из списка.");
                break;
        }
    }

    public static void ShowCreateNewFile()
    {
        Console.Write("Введите имя нового файла: ");

        string? fileNameInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileNameInput))
        {
            Console.WriteLine("Неверный ввод. Имя файла не может быть пустым.");
            return;
        }

        string newFilePath = Path.Combine(DataStorage.DataFolderPath, $"{fileNameInput}.json");

        if (FileHandler.FileExists(newFilePath))
        {
            Console.WriteLine("Файл с таким именем уже существует. Невозможно создать новый файл.");
            return;
        }

        DataStorage.CreateNewFile(fileNameInput);
        Console.WriteLine("\nДанные сохранены в новый файл.");
    }

    public static void ShowAllFiles()
    {
        string[] files = FileHandler.GetFiles(DataStorage.DataFolderPath);

        if (files.Length == 0)
        {
            Console.WriteLine("Сохранений нет.");
            return;
        }

        Console.WriteLine("\nСписок файлов сохранения:");

        for (int i = 0; i < files.Length; i++)
        {
            string fileName = Path.GetFileName(files[i]);
            Console.WriteLine($"{i + 1}. {fileName}");
        }
    }

    public static void DeleteFile()
    {
        Console.Write("Выберите файл для удаления: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int fileIndex) && fileIndex > 0)
        {
            string[] files = FileHandler.GetFiles(DataStorage.DataFolderPath);

            if (fileIndex <= files.Length)
            {
                string filePath = files[fileIndex - 1];
                string fileName = Path.GetFileName(filePath);
                FileHandler.DeleteFile(filePath);
                Console.WriteLine($"Файл {fileName} успешно удален.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите допустимый номер файла.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, выберите допустимый номер файла.");
        }
    }

    public static void WriteToExistingFile()
    {
        Console.WriteLine("\nСписок файлов сохранения:");
        string[] files = FileHandler.GetFiles(DataStorage.DataFolderPath);

        for (int i = 0; i < files.Length; i++)
        {
            string fileName = Path.GetFileName(files[i]);
            Console.WriteLine($"{i + 1}. {fileName}");
        }

        Console.Write("\nВыберите файл для записи: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int fileIndex) && fileIndex > 0 && fileIndex <= files.Length)
        {
            DataStorage.Save(fileIndex);
            Console.WriteLine("\nДанные сохранены в существующий файл.");
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, выберите допустимый номер файла.");
        }
    }
}


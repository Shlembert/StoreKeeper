public class FileHandler
{
    public static string[] GetFiles(string folderPath)
    {
        return Directory.GetFiles(folderPath);
    }

    public static bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public static void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    public static string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static void WriteFile(string filePath, string jsonData)
    {
        File.WriteAllText(filePath, jsonData);
    }
}

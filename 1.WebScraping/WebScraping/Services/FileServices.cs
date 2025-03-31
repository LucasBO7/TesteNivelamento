using System.IO.Compression;

namespace WebScraping.Services;

internal static class FileServices
{
    public static void CreateZipFile(string[] files, string zipFilePath)
    {
        using (var zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
        {
            foreach (var file in files)
            {
                // Adicionando cada arquivo ao ZIP
                zip.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }

        Console.WriteLine("Arquivo ZIP criado com sucesso!");
    }


    public static void CreateFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
    }

    private static readonly string ZIPPED_FOLDER_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebScraping_Downloads\\compactacoes");

    public static void SaveFilesToFolder(string folderPath)
    {
        string[] filesPaths = Directory.GetFiles(folderPath).Where(file => file.EndsWith(".pdf")).ToArray();
        string generatedFolderPath = $"{folderPath}\\anexos{DateTime.Now:HHMMdd_hhmmss}";

        foreach (var filePath in filesPaths)
        {
            CreateFolder(generatedFolderPath);
            File.Move(filePath, Path.Combine(generatedFolderPath, Path.GetFileName(filePath)));

            Console.WriteLine($"Arquivo {Path.GetFileName(filePath)} salvo!");
        }
    }

    public static void CreateZipFromFolder(string folderPath)
    {
        CreateFolder(ZIPPED_FOLDER_PATH);

        // Gera um nome único para o arquivo ZIP usando a data e hora atual
        string zipFilePath = Path.Combine(ZIPPED_FOLDER_PATH, $"anexosCompactados_{DateTime.Now:HHMMdd_hhmmss}.zip");

        // Se o arquivo já existir, exclui-o antes de criar
        if (File.Exists(zipFilePath))
            File.Delete(zipFilePath);

        // Compacta toda a pasta no arquivo ZIP
        ZipFile.CreateFromDirectory(folderPath, zipFilePath, CompressionLevel.Fastest, true);
        Console.WriteLine($"Pasta compactada em: {zipFilePath}");

        // Exclui a pasta original após a compactação
        DeleteOldSubFolders(folderPath);
    }

    private static void DeleteOldSubFolders(string folderPath)
    {
        var subFolders = Directory.GetDirectories(folderPath).Where(subFolder => !subFolder.Contains("compactacoes"));

        foreach (var subFolder in subFolders)
        {
            Directory.Delete(subFolder, true);
        }
    }

}
namespace WebScraping.Services;

internal class PdfManager
{
    public string FolderPath { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebScraping_Downloads\\arquivos_pdfs");
    public string FileName { get; private set; } = "arquivoPDF";

    public PdfManager() { }

    public PdfManager(string newFileName)
    {
        FileName = newFileName;
    }

    public void SetFileName(string fileName)
    {
        FileName = fileName;
    }

    public async Task DownloadPdfFromUrl(string url, int currentPdfCount)
    {
        using HttpClient client = new();

        FileServices.CreateFolder(FolderPath);

        Console.WriteLine($"Baixando PDF...");
        var pdfBytes = await client.GetByteArrayAsync(url);

        string fullFilePath = Path.Combine(FolderPath, $"{FileName}.pdf");

        await File.WriteAllBytesAsync(fullFilePath!, pdfBytes);

        Console.WriteLine($"PDF baixado com sucesso!");
        Console.WriteLine();
    }
}
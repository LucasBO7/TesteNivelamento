using WebScraping.Services;

DriverEngine driverEngine = new();
PdfManager pdfManager = new();

driverEngine.OpenWebsite("https://www.gov.br/ans/pt-br/acesso-a-informacao/participacao-da-\r\nsociedade/atualizacao-do-rol-de-procedimentos");

// Aceita os cookies
driverEngine.ClickInByXPath("/html/body/div[5]/div/div/div/div/div[2]/button[3]");

// Baixa os PDFs
Dictionary<string, string> anexosXPath = [];
anexosXPath["Anexo1"] = "//*[@id=\"cfec435d-6921-461f-b85a-b425bc3cb4a5\"]/div/ol/li[1]/a[1]";
anexosXPath["Anexo2"] = "//*[@id=\"cfec435d-6921-461f-b85a-b425bc3cb4a5\"]/div/ol/li[2]/a";

foreach (var anexoXPath in anexosXPath)
{
    string anexoLinkUrl = driverEngine.GetHrefLink(anexoXPath.Value);
    pdfManager.SetFileName(anexoXPath.Key);

    await pdfManager.DownloadPdfFromUrl(anexoLinkUrl, 1);
}

driverEngine.Dispose();



// Cria a pasta
FileServices.CreateFolder(pdfManager.FolderPath!);

// Adiciona arquivos à pasta
FileServices.SaveFilesToFolder(pdfManager.FolderPath!);

// Compacta a pasta inteira
FileServices.CreateZipFromFolder(pdfManager.FolderPath);

Console.WriteLine("Processo concluído com sucesso!");
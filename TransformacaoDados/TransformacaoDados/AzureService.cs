using Azure.AI.Vision.ImageAnalysis;
using Azure;
using UglyToad.PdfPig;
using PdfiumViewer;

namespace TransformacaoDados;

internal class AzureService
{
    public const string EndPoint = "https://teste-tecnico-computer-vision.cognitiveservices.azure.com/";
    public const string Key = "6rmOwGAslno2TLZbYKtyTK99I389H5k0EgiTFhvS3QN8DHlsB0ExJQQJ99BCACYeBjFXJ3w3AAAFACOGqLj7";

    public static void ExtractTextFromImage(string imagePath)
    {
        // Configurar o cliente Azure Vision
        var credentials = new AzureKeyCredential(Key);
        var client = new ImageAnalysisClient(new Uri(EndPoint), credentials);

        // Carregar a imagem
        using FileStream stream = new(imagePath, FileMode.Open);

        // Configurar opções do OCR
        var options = new ImageAnalysisOptions()
        {
            //Features = { ImageAnalysisFeature.Read } // OCR para leitura de texto
            GenderNeutralCaption = true
        };

        // Processar a imagem
        ImageAnalysisResult result = client.Analyze(BinaryData.FromStream(stream), VisualFeatures.Read);

        // Exibir resultado
        if (result.Read != null)
        {
            Console.WriteLine("Texto extraído:");
            foreach (var block in result.Read.Blocks)
            {
                foreach (DetectedTextLine line in block.Lines)
                {
                    Console.WriteLine(line.Text);
                }
            }
        }
        else
            Console.WriteLine("Nenhum texto foi detectado.");

    }

    // 🔹 Método para converter uma página do PDF em imagem
    public static string ConvertPdfPageToImage(string pdfPath, int pageNumber)
    {
        using var document = PdfiumViewer.PdfDocument.Load(pdfPath);
        using var image = document.Render(pageNumber, 300, 300, true);

        string imagePath = "pagina.png";
        image.Save(imagePath);
        return imagePath;
    }
}
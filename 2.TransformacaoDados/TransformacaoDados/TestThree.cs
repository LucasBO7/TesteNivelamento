using CsvHelper;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace TransformacaoDados
{
    internal class TestThree
    {
//        string outputCsvPath = "C:\\Users\\lucas\\Desktop\\output.csv";

//        int pageNumber = 5; // Número da página para processar
//        string text = ExtractTextWithOCR(pdfFilePath, pageNumber);
//        Console.WriteLine("Texto extraído da página " + pageNumber + ":");
//Console.WriteLine(text);

//using (var writer = new StreamWriter(outputCsvPath))
//using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
//{
//    csv.WriteField("Página");
//    csv.WriteField("Texto Extraído");
//    csv.NextRecord();

//    using (var pdf = PdfDocument.Open(pdfFilePath))
//    {
//        int pageNum = 1;

//        foreach (var page in pdf.GetPages())
//        {
//            string extractedText = ContentOrderTextExtractor.GetText(page);

//            if (string.IsNullOrWhiteSpace(extractedText)) // Se não há texto, usar OCR
//            {
//                extractedText = ExtractTextWithOCR(pdfFilePath, pageNum);
//    }

//    csv.WriteField($"Página {pageNum}");
//            csv.WriteField(extractedText);
//            csv.NextRecord();

//            pageNum++;
//        }
//    }
//}

//Console.WriteLine("Conversão concluída. Arquivo salvo como output.csv.");

//static string ExtractTextWithOCR(string pdfPath, int pageNumber)
//{
//    // Carregar o PDF e renderizar a página como uma imagem
//    using (var pdfDoc = PdfiumViewer.PdfDocument.Load(pdfPath))
//    {
//        using (var img = pdfDoc.Render(pageNumber - 1, 300, 300, PdfRenderFlags.Grayscale))
//        {
//            // Convertendo a imagem para Pix
//            using (var pix = BitmapToPix((Bitmap)img))
//            {
//                // Usando o Tesseract para extrair o texto da imagem
//                using (var ocrEngine = new TesseractEngine(@"./tessdata", "por", EngineMode.Default))
//                {
//                    return ocrEngine.Process(pix).GetText();
//                }
//            }
//        }
//    }
//}

//static Pix BitmapToPix(System.Drawing.Bitmap img)
//{
//    using (var ms = new MemoryStream())
//    {
//        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Salva a imagem em memória como PNG
//        return Pix.LoadFromMemory(ms.ToArray()); // Converte o PNG em memória para Pix
//    }
//}
    }
}

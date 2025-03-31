using System.Globalization;
using System.Text.RegularExpressions;
using Tesseract;
using CsvHelper;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using PdfiumViewer;
using System.Drawing;
using PdfDocument = UglyToad.PdfPig.PdfDocument;
using CsvHelper.Configuration;

Console.Write("Insira o caminho o qual o arquivo está localizado: ");
string pdfFilePath = Console.ReadLine()!;

pdfFilePath = @"C:\Users\lucas\Documents\WebScraping_Downloads\compactacoes\anexosCompactados_204007\arquivos_pdfs\anexos202809\Anexo1.pdf";
string outputCsvPath = "C:\\Users\\lucas\\Desktop\\output.csv";

int pageNumber = 5; // Número da página para processar
string text = ExtractTextWithOCR(pdfFilePath, pageNumber);
Console.WriteLine("Texto extraído da página " + pageNumber + ":");
Console.WriteLine(text);

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    Delimiter = ";",
};

using (var writer = new StreamWriter(outputCsvPath))
using (var csv = new CsvWriter(writer, config))
{
    // Escrever o cabeçalho no CSV
    csv.WriteField("Página");
    csv.WriteField("PROCEDIMENTO");
    csv.WriteField("RN(alteração)");
    csv.WriteField("VIGÊNCIA");
    csv.WriteField("OD");
    csv.WriteField("AMB");
    csv.WriteField("HCO");
    csv.WriteField("HSO");
    csv.WriteField("REF");
    csv.WriteField("PAC");
    csv.WriteField("DUT");
    csv.WriteField("SUBGRUPO");
    csv.WriteField("GRUPO");
    csv.WriteField("CAPÍTULO");
    csv.NextRecord();

    // Processa apenas a página específica
    using (var pdf = PdfDocument.Open(pdfFilePath))
    {
        var page = pdf.GetPage(pageNumber - 1);
        string extractedText = ContentOrderTextExtractor.GetText(page);

        if (string.IsNullOrWhiteSpace(extractedText))
        {
            extractedText = ExtractTextWithOCR(pdfFilePath, pageNumber);
        }

        extractedText = RemoveLegenda(extractedText);

        var tableRows = ProcessTableRows(extractedText);

        foreach (var row in tableRows)
        {
            csv.WriteField($"Página {pageNumber}");
            csv.WriteField(row.Procedimento);
            csv.WriteField(row.RnAlteracao);
            csv.WriteField(row.Vigencia);
            csv.WriteField(row.Od);
            csv.WriteField(row.Amb);
            csv.WriteField(row.Hco);
            csv.WriteField(row.Hso);
            csv.WriteField(row.Ref);
            csv.WriteField(row.Pac);
            csv.WriteField(row.Dut);
            csv.WriteField(row.Subgrupo);
            csv.WriteField(row.Grupo);
            csv.WriteField(row.Capitulo);
            csv.NextRecord();
        }
    }
}

Console.WriteLine("Conversão concluída. Arquivo salvo como output.csv.");

static string RemoveLegenda(string extractedText)
{
    // Regex para remover a legenda, começando após a palavra "Legenda:"
    string legendaPattern = @"Legenda:\s*(OD:.*?DUT:.*?)(?=\s*PROCEDIMENTO)";
    return Regex.Replace(extractedText, legendaPattern, "", RegexOptions.Singleline);
}

// Função para processar as linhas da tabela
static List<TableRow> ProcessTableRows(string text)
{
    var rows = new List<TableRow>();

    // Regex para identificar as linhas da tabela com mais precisão
    var tableRowPattern = @"(?<=PROCEDIMENTO)(.*?)(?=\d{3,4}\/\d{4})\s*(\d{3,4}\/\d{4})\s*(\d{2}\/\d{2}\/\d{4})\s*(OD|AMB|HCO|HSO|REF|PAC|DUT)(.*?)\s*(\w+)\s*(\w+)\s*(\w+)\s*(\w+)\s*(\w+)\s*(\w+)\s*(\w+)\s*(\w+)(?=\s*PROCEDIMENTO|\z)";

    foreach (Match match in Regex.Matches(text, tableRowPattern, RegexOptions.Singleline))
    {
        var row = new TableRow
        {
            Procedimento = match.Groups[1].Value.Trim(),
            RnAlteracao = match.Groups[2].Value.Trim(),
            Vigencia = match.Groups[3].Value.Trim(),
            Od = match.Groups[4].Value.Trim(),
            Amb = match.Groups[5].Value.Trim(),
            Hco = match.Groups[6].Value.Trim(),
            Hso = match.Groups[7].Value.Trim(),
            Ref = match.Groups[8].Value.Trim(),
            Pac = match.Groups[9].Value.Trim(),
            Dut = match.Groups[10].Value.Trim(),
            Subgrupo = match.Groups[11].Value.Trim(),
            Grupo = match.Groups[12].Value.Trim(),
            Capitulo = match.Groups[13].Value.Trim()
        };

        rows.Add(row);
    }

    return rows;
}


static string ExtractTextWithOCR(string pdfPath, int pageNumber)
{
    // Carregar o PDF e renderizar a página como uma imagem
    using (var pdfDoc = PdfiumViewer.PdfDocument.Load(pdfPath))
    {
        using (var img = pdfDoc.Render(pageNumber - 1, 300, 300, PdfRenderFlags.Grayscale))
        {
            using (var pix = BitmapToPix((Bitmap)img))
            {
                using (var ocrEngine = new TesseractEngine(@"./tessdata", "por", EngineMode.Default))
                {
                    return ocrEngine.Process(pix).GetText();
                }
            }
        }
    }
}

static Pix BitmapToPix(System.Drawing.Bitmap img)
{
    using (var ms = new MemoryStream())
    {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Salva a imagem em memória como PNG
        return Pix.LoadFromMemory(ms.ToArray()); // Converte o PNG em memória para Pix
    }
}

// Classe para representar uma linha da tabela
class TableRow
{
    public string Procedimento { get; set; }
    public string RnAlteracao { get; set; }
    public string Vigencia { get; set; }
    public string Od { get; set; }
    public string Amb { get; set; }
    public string Hco { get; set; }
    public string Hso { get; set; }
    public string Ref { get; set; }
    public string Pac { get; set; }
    public string Dut { get; set; }
    public string Subgrupo { get; set; }
    public string Grupo { get; set; }
    public string Capitulo { get; set; }
}




//var pdf = new IronPdf.PdfDocument(pdfFilePath);

//var extractedText = pdf.ExtractTextFromPage(5);

//Console.WriteLine("Texto extraído:");
//Console.WriteLine(extractedText);

//string csvFormattedText = extractedText.Replace("\n", ";").Replace("\r", "");
//Console.WriteLine("Texto formatado:");
//Console.WriteLine(csvFormattedText);


//using PdfDocument pdfDocument = PdfDocument.Open(pdfFilePath);
//PdfService pdfService = new();

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;
//using CsvHelper;
//using System.Globalization;


#region Try_1

//string caminhoArquivoCsv = "C:\\Users\\lucas\\Documents\\WebScraping_Downloads\\" + "procedimentos_saude.csv";

//try
//{
//    var procedimentos = PdfExtractor.ExtrairProcedimentosDoPdf(pdfFilePath);
//    PdfExtractor.SalvarEmCsv(procedimentos, caminhoArquivoCsv);
//    Console.WriteLine($"Extração concluída. {procedimentos.Count} registros processados.");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Erro durante extração: {ex.Message}");
//}

//public class ProcedimentoSaude
//{
//    public string Procedimento { get; set; }
//    public string RN { get; set; }
//    public string Vigencia { get; set; }
//    public string OD { get; set; }
//    public string AMB { get; set; }
//    public string HCO { get; set; }
//    public string HSO { get; set; }
//    public string REF { get; set; }
//    public string PAC { get; set; }
//    public string DUT { get; set; }
//    public string Subgrupo { get; set; }
//    public string Grupo { get; set; }
//    public string Capitulo { get; set; }
//}

//public class PdfExtractor
//{
//    public static List<ProcedimentoSaude> ExtrairProcedimentosDoPdf(string caminhoArquivoPdf)
//    {
//        int counter = 0;
//        var procedimentos = new List<ProcedimentoSaude>();

//        using (var documento = PdfDocument.Open(caminhoArquivoPdf))
//        {
//            foreach (var pagina in documento.GetPages())
//            {
//                if (counter <= 3)
//                {
//                    counter++;
//                    continue;
//                }

//                var palavras = pagina.GetWords()
//                    .OrderBy(w => w.BoundingBox.Bottom)
//                    .ThenBy(w => w.BoundingBox.Left)
//                    .Select(w => w.Text)
//                    .ToList();

//                var linhasDados = IdentificarLinhasDeDados(palavras);

//                linhasDados.ForEach(l => Console.WriteLine(l));
//                Console.ReadLine();

//                foreach (var linha in linhasDados)
//                {
//                    var procedimento = ParseirLinhaProcedimento(linha);
//                    if (procedimento != null)
//                    {
//                        procedimentos.Add(procedimento);
//                    }
//                }

//                counter++;

//                if (counter >= 5)
//                    break;
//            }
//        }

//        return procedimentos;
//    }

//    private static int EncontrarIndiceTabelaDados(List<string> linhas)
//    {
//        // Lógica para identificar o início da tabela de dados
//        for (int i = 0; i < linhas.Count; i++)
//        {
//            if (linhas[i].Contains("PROCEDIMENTO") &&
//                linhas[i].Contains("RN") &&
//                linhas[i].Contains("VIGÊNCIA"))
//            {
//                return i + 1;
//            }
//        }
//        return -1;
//    }

//    private static List<string> IdentificarLinhasDeDados(List<string> palavras)
//    {
//        var linhasDados = new List<string>();
//        var cabeçalhoEsperado = new[] { "PROCEDIMENTO", "RN", "VIGÊNCIA", "OD", "AMB", "HCO", "HSO", "REF", "PAC", "DUT" };

//        // Encontrar índice do cabeçalho
//        int indiceInicio = -1;
//        for (int i = 0; i < palavras.Count; i++)
//        {
//            if (cabeçalhoEsperado.Contains(palavras[i]))
//            {
//                indiceInicio = i;
//                break;
//            }
//        }

//        if (indiceInicio == -1) return linhasDados;

//        for (int i = indiceInicio + cabeçalhoEsperado.Length; i < palavras.Count; i++)
//        {
//            // Condições para identificar uma linha de dados
//            if (EhLinhaDeDados(palavras.Skip(i).Take(5).ToList()))
//            {
//                var linha = string.Join(" ", palavras.Skip(i).Take(10));
//                linhasDados.Add(linha);

//                // Pular palavra já processadas
//                i += 9;
//            }
//        }

//        return linhasDados;
//    }

//    private static bool EhLinhaDeDados(List<string> palavras)
//    {
//        // Lógica para identificar se um conjunto de palavras representa uma linha de dados
//        var regex = new Regex(@"^[A-ZÇÃÕ]");
//        return palavras.Any(p => regex.IsMatch(p)) &&
//               palavras.Any(p => Regex.IsMatch(p, @"\d{2}/\d{2}/\d{4}|\d+"));
//    }


//    private static ProcedimentoSaude ParseirLinhaProcedimento(string linha)
//    {
//        try
//        {
//            // Regex mais robusto para parsing
//            var regex = new Regex(@"^(.*?)\s*(\(.*?\))?\s*(\d{2}/\d{2}/\d{4})?\s*([A-Z]+)?\s*(.*)$");
//            var match = regex.Match(linha);

//            if (match.Success)
//            {
//                return new ProcedimentoSaude
//                {
//                    Procedimento = match.Groups[1].Value.Trim(),
//                    RN = match.Groups[2].Value.Trim('(', ')'),
//                    Vigencia = match.Groups[3].Value.Trim(),
//                    OD = match.Groups[4].Value.Trim(),
//                    // Outros campos podem ser extraídos com lógica similar
//                };
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Erro ao parsear linha: {linha}. Erro: {ex.Message}");
//        }

//        return null;
//    }


//    public static void SalvarEmCsv(List<ProcedimentoSaude> procedimentos, string caminhoArquivoCsv)
//    {
//        using (var escritor = new StreamWriter(caminhoArquivoCsv))
//        using (var csv = new CsvWriter(escritor, CultureInfo.InvariantCulture))
//        {
//            csv.WriteRecords(procedimentos);
//        }
//    }
//}
#endregion

#region Try_2
/*

try
{
    string pdfPath = pdfFilePath;

    int pageNumber = 4;

    string imagePath = AzureService.ConvertPdfPageToImage(pdfPath, pageNumber);

    List<string> extractedLines = new List<string>();

    var credentials = new AzureKeyCredential(AzureService.Key);
    var client = new ImageAnalysisClient(new Uri(AzureService.EndPoint), credentials);

    using FileStream stream = new(imagePath, FileMode.Open);

    var options = new ImageAnalysisOptions()
    {
        GenderNeutralCaption = true
    };

    ImageAnalysisResult result = client.Analyze(BinaryData.FromStream(stream), VisualFeatures.Read);

    // Coletar linhas extraídas
    if (result.Read != null)
    {
        foreach (var block in result.Read.Blocks)
        {
            foreach (DetectedTextLine line in block.Lines)
            {
                // Adicionar linha não vazia à lista
                if (!string.IsNullOrWhiteSpace(line.Text))
                {
                    extractedLines.Add(line.Text);
                }
            }
        }
    }
    else
    {
        Console.WriteLine("Nenhum texto foi detectado.");
        return;
    }

    // Caminho de saída para o arquivo CSV
    string csvOutputPath = @"C:\\Users\\lucas\\Documents\\WebScraping_Downloads\\" + "procedimentos_saude.csv";

    // Exportar para CSV
    TextExtractor textExtractor = new();
    textExtractor.ExportToCsv(extractedLines, csvOutputPath);

    Console.WriteLine("Processo concluído com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro durante o processamento: {ex.Message}");
    Console.WriteLine($"Detalhes do erro: {ex.StackTrace}");
}

public class ProcedimentoSaude
{
    public string Capitulo { get; set; }
    public string Grupo { get; set; }
    public string Subgrupo { get; set; }
    public string Procedimento { get; set; }
    public string Rn { get; set; }
    public string Vigencia { get; set; }
    public string ModalidadesCobertura { get; set; }
    public string Complexidade { get; set; }
}

public class ProcedimentoSaudeMapper : ClassMap<ProcedimentoSaude>
{
    public ProcedimentoSaudeMapper()
    {
        Map(m => m.Capitulo).Name("Capitulo");
        Map(m => m.Grupo).Name("Grupo");
        Map(m => m.Subgrupo).Name("Subgrupo");
        Map(m => m.Procedimento).Name("Procedimento");
        Map(m => m.Rn).Name("RN");
        Map(m => m.Vigencia).Name("Vigencia");
        Map(m => m.ModalidadesCobertura).Name("Modalidades Cobertura");
        Map(m => m.Complexidade).Name("Complexidade");
    }
}

public class TextExtractor
{
    public void ExportToCsv(List<string> extractedLines, string outputPath)
    {
        var procedimentos = new List<ProcedimentoSaude>();
        ProcedimentoSaude currentProcedimento = null;

        foreach (var line in extractedLines)
        {
            if (IsCapitulo(line))
            {
                if (currentProcedimento != null)
                {
                    procedimentos.Add(currentProcedimento);
                }
                currentProcedimento = new ProcedimentoSaude { Capitulo = line };
            }
            else if (currentProcedimento != null)
            {
                if (IsGrupo(line))
                {
                    currentProcedimento.Grupo = line;
                }
                else if (IsSubgrupo(line))
                {
                    currentProcedimento.Subgrupo = line;
                }
                else if (IsProcedimento(line))
                {
                    currentProcedimento.Procedimento = line;
                }
                else if (IsRn(line))
                {
                    currentProcedimento.Rn = line;
                }
                else if (IsVigencia(line))
                {
                    currentProcedimento.Vigencia = line;
                }
                else if (IsModalidade(line))
                {
                    currentProcedimento.ModalidadesCobertura += line + "; ";
                }
            }
            else
            {
                currentProcedimento = new ProcedimentoSaude
                {
                    Procedimento = line
                };
            }
        }

        if (currentProcedimento != null)
        {
            procedimentos.Add(currentProcedimento);
        }

        using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.Context.RegisterClassMap<ProcedimentoSaudeMapper>();
            csv.WriteRecords(procedimentos);
        }

        Console.WriteLine($"CSV exportado com sucesso para {outputPath}");
    }


    private static bool IsCapitulo(string line) =>
        line.Contains("CAPÍTULO", StringComparison.OrdinalIgnoreCase);

    private static bool IsGrupo(string line) =>
        line.Contains("GRUPO", StringComparison.OrdinalIgnoreCase);

    private static bool IsSubgrupo(string line) =>
        line.Contains("SUBGRUPO", StringComparison.OrdinalIgnoreCase);

    private static bool IsProcedimento(string line) =>
        !string.IsNullOrWhiteSpace(line) &&
        line.Length > 10 &&
        !IsCapitulo(line) &&
        !IsGrupo(line) &&
        !IsSubgrupo(line);

    private static bool IsRn(string line) =>
        line.StartsWith("RN", StringComparison.OrdinalIgnoreCase);

    private static bool IsVigencia(string line) =>
        System.Text.RegularExpressions.Regex.IsMatch(line, @"\d{2}/\d{2}/\d{4}");

    private static bool IsModalidade(string line) =>
        new[] { "AMB", "HCO", "HSO", "REF", "PAC", "DUT" }.Any(m => line.Contains(m));
}
*/
#endregion


//OPÇÃO 3
//string imagePath = AzureService.ConvertPdfPageToImage(pdfFilePath, 4);
//AzureService.ExtractTextFromImage(imagePath);




//OPÇÃO 2
//using (StreamWriter writer = new StreamWriter("C:\\Users\\lucas\\Documents\\saida.csv"))
//{
//    writer.WriteLine("Procedimento;RN Alteração;Vigência;OD;AMB;HCO;HSO;REF;PAC;DUT;Subgrupo;Grupo;Capítulo;");

//    foreach (var page in pdfDocument.GetPages())
//    {
//        string[] lines = page.Text.Split('\n');

//        foreach (string line in lines)
//        {
//            // Supondo que os dados estejam separados por múltiplos espaços
//            var columns = line.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);

//            if (columns.Length > 1)
//            {
//                string csvLine = string.Join(";", columns.Select(c => c.Trim()));
//                writer.WriteLine(csvLine);
//            }
//        }
//    }
//}

//foreach (var page in pdfDocument.GetPages())
//{
//    string text = page.Text;
//    Console.WriteLine(text);
//}

//pdfService.ExtractDataFromPages(pdfDocument);
//pdfService.PrintWords();
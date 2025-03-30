using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace TransformacaoDados;

internal class PdfService
{
    public int counter = 1;
    public Dictionary<int, List<Word>> words = [];

    public void ExtractDataFromPages(UglyToad.PdfPig.PdfDocument document)
    {
        foreach (var page in document.GetPages())
        {
            Console.WriteLine($"Página {page.Number}:");

            // Extrair todo o texto da página
            string pageText = page.Text;

            // Extrair todos os blocos de texto da página
            var words = page.GetWords().OrderBy(w => w.BoundingBox.Bottom).ThenBy(w => w.BoundingBox.Left);
            string fullPageText = string.Join(" ", words.Select(w => w.Text));

            // Remover cabeçalhos, rodapés e outras informações não relevantes
            fullPageText = Regex.Replace(fullPageText, @"Rol de Procedimentos.*|Legenda:.*", "", RegexOptions.Singleline);

            // Dividir o texto em linhas mantendo a estrutura
            var linhas = fullPageText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(linha => !string.IsNullOrWhiteSpace(linha))
                .ToList();


            linhas.ForEach(a => Console.WriteLine(a));

            //if (counter >= 3)
            //{
            //    //words[page.Number] = page.GetWords().Take(5).ToList();
            //    words[page.Number] = page.GetWords().ToList();

            //    //foreach (Word word in page.GetWords())
            //    //{
            //    //    Console.WriteLine("________________________");
            //    //    Console.WriteLine("Texto: " + word.Text);
            //    //    Console.WriteLine("Orientação: " + word.TextOrientation);
            //    //    Console.WriteLine("Boundig Box: " + word.BoundingBox.Area);
            //    //    Console.WriteLine("Boundig Box: " + word.BoundingBox.Centroid);
            //    //    Console.WriteLine("________________________");
            //    //}
            //}

            ////Console.WriteLine();
            ////Console.WriteLine("VIROU A PÁGINA");
            ////Console.WriteLine();
            counter++;

            if (counter == 5)
                break;
        }
    }

    public void PrintWords()
    {
        foreach (var item in words)
        {
            Console.WriteLine("Página " + item.Key);

            item.Value.ForEach(PrintWord);
        }
    }

    private void PrintWord(Word word)
    {
        Console.WriteLine(@$"
________________________
Texto: {word.Text}
Orientação: {word.TextOrientation}
Boundig Box Area: {word.BoundingBox.Area}
Boundig Box CentroId: {word.BoundingBox.Centroid}
________________________");
    }
}
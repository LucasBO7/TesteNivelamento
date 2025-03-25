using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraping.Services;

internal class DriverEngine : IDisposable
{
    private readonly IWebDriver _driver;

    public DriverEngine()
    {
        var chromeOptions = new ChromeOptions();

        // Método 1: Desabilitar logs do Chrome
        chromeOptions.AddArgument("--disable-logging");
        chromeOptions.AddArgument("--log-level=3"); // Apenas erros críticos

        // Método 2: Suprimir logs do ChromeDriver
        var chromeDriverService = ChromeDriverService.CreateDefaultService();
        chromeDriverService.SuppressInitialDiagnosticInformation = true;
        chromeDriverService.HideCommandPromptWindow = true;

        // Desabilitar logs de saída padrão
        chromeDriverService.EnableVerboseLogging = false;

        // Redirecionar logs para um arquivo de texto ou para null
        chromeDriverService.LogPath = "nul"; // No Windows
                                             // chromeDriverService.LogPath = "/dev/null"; // No Linux/Mac

        // Configurações adicionais para minimizar logs
        chromeOptions.AddArgument("--no-sandbox");
        chromeOptions.AddArgument("--disable-dev-shm-usage");

        _driver = new ChromeDriver(chromeDriverService, chromeOptions);
    }

    public void OpenWebsite(string websiteUrl)
    {
        _driver.Navigate().GoToUrl(websiteUrl);
    }

    public void ClickInByXPath(string elementXPath)
    {
        var foundElement = _driver.FindElement(OpenQA.Selenium.By.XPath(elementXPath));

        foundElement.Click();
    }

    public string GetHrefLink(string elementXPath)
    {
        var foundElement = _driver.FindElement(OpenQA.Selenium.By.XPath(elementXPath));

        return foundElement.GetAttribute("href") ?? "";
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
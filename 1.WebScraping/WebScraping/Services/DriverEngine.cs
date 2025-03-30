using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraping.Services;

internal class DriverEngine : IDisposable
{
    private readonly IWebDriver _driver;

    public DriverEngine()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless=new");

        #region Desabilita_Logs
        chromeOptions.AddArgument("--disable-logging");
        chromeOptions.AddArgument("--log-level=3");
        var chromeDriverService = ChromeDriverService.CreateDefaultService();
        chromeDriverService.SuppressInitialDiagnosticInformation = true;
        chromeDriverService.HideCommandPromptWindow = true;
        chromeDriverService.EnableVerboseLogging = false;
        chromeDriverService.LogPath = "nul"; // Windows
        chromeDriverService.LogPath = "/dev/null"; // Linux/Mac
        chromeOptions.AddArgument("--no-sandbox");
        chromeOptions.AddArgument("--disable-dev-shm-usage");
        #endregion

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
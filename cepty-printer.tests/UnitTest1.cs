using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace cepty_printer.tests;

public class GoogleTests : IDisposable
{
    private readonly IWebDriver _driver;
    public GoogleTests()
    {
        _driver = new ChromeDriver(); // Asegúrate de tener Chrome instalado
    }
    [Fact]
    public void GoogleSearch_ShouldReturnResults()
    {
        _driver.Navigate().GoToUrl("https://www.google.com");

        var searchBox = _driver.FindElement(By.Name("q"));
        searchBox.SendKeys("Selenium C#");
        searchBox.Submit();

        // Espera corta y luego verifica que el título contenga lo que buscamos
        System.Threading.Thread.Sleep(2000); // Para pruebas reales usa WebDriverWait

        Assert.Contains("Selenium C#", _driver.Title);
    }

    [Fact]
    public void Login_Zendesk()
    {
        _driver.Navigate().GoToUrl("https://assanetdev.zendesk.com/");
        var username = _driver.FindElement(By.Id("user_email"));
        username.SendKeys("jbasalo@assanet.com");
        var password = _driver.FindElement(By.Id("user_password"));
        password.SendKeys("oks3W84HCZG&GK9");

        var btn = _driver.FindElement(By.Id("sign-in-submit-button"));

        btn.Click();


        System.Threading.Thread.Sleep(5000);
    }

    public void Dispose()
    {
        _driver.Quit(); // Cierra el navegador al terminar
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Lesson2_demoSelenium
{
    public class Tests
    {
       private IWebDriver driver;

        [Test]
        public void Test1()
        {
            IWebDriver driver;
            driver = new ChromeDriver();

            driver.Url = "https://www.google.com/";
            string currentUrl = driver.Url;

            driver.Navigate().GoToUrl("https://www.litecart.net/demo");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            driver.Manage().Window.Minimize();
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Size = new System.Drawing.Size(800, 600);


            string title = driver.Title;
            string pageSrc = driver.PageSource;

            driver.Close();

            Assert.Pass();
        }
        [SetUp]
        public void SetUpTest()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.saucedemo.com/v1/";
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            driver.Dispose();
        }
        [Test]
        public void ErrorMessageShouldBeShown_WhenInvalidUserNameAndPasswordEntered()
        {
            string errorMessage = "Epic sadface: Username and password do not match any user in this service";
     
            IWebElement loginText = driver.FindElement(By.Id("user-name"));
            IWebElement passwordText = driver.FindElement(By.Id("password"));

            bool isDisplayed = loginText.Displayed;
            bool isEnabled = loginText.Enabled;
            string text = loginText.Text;
            string tag = loginText.TagName;
            var css = loginText.GetCssValue("color");

            loginText.SendKeys("login");
            loginText.Clear();
            loginText.SendKeys("superUser");
            loginText.SendKeys(Keys.Backspace);
            loginText.Submit();

            passwordText.SendKeys("qwerty");
            passwordText.SendKeys(Keys.Enter);

            IWebElement loginBtn = driver.FindElement(By.Id("login-button"));
            loginBtn.Click();

            IWebElement error = driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.That(error.Text == errorMessage);


        }
    }
}
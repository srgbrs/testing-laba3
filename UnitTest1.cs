using NUnit.Framework;
using OpenQA.Selenium;

namespace компоненты_лаб3
{
    public class Tests
    {
        private IWebDriver driver;

        private By _button = By.XPath("//*[@id=\"header\"]/div[1]/div/div[1]");
       // private By _log = By.XPath("//*[@id=\"enter - layer\"]/form/label[1]/span/input");
        private By _log = By.XPath("/html/body/div[14]/div/div[2]/div/form/label[1]/span/input");
        private By _pas = By.XPath("/html/body/div[14]/div/div[2]/div/form/label[2]/span/input");

        private By _loginBtn = By.XPath("/html/body/div[14]/div/div[2]/div/form/div[1]/button");

        private By _emailCheck = By.CssSelector(".td.value.field.required");

        private By _link = By.ClassName("lookall");

        private By _registrationName = By.Name("firstname");
        private By _registrationSecondName = By.Name("patronymic");
        private By _registrationSurname = By.Name("surname");
        private By _registrationEmail = By.Name("email");

        private By _registrationButton = By.ClassName("butt4");

        private By _errorMessage = By.XPath("//*[@id=\"error-hint-layer\"]");

        private By _cartButton = By.ClassName("cart");
        private By _cartMessage = By.ClassName("empty");

        private By _anyLink = By.LinkText("veliki.com.ua/dir_press-exercise-machines.htm");


        [SetUp] 
        public void Setup() // срабатывает перед тестом
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://veliki.com.ua");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var sign = driver.FindElement(_button);
            sign.Click();
            System.Threading.Thread.Sleep(2000);


            var IN = driver.FindElement(_log);
            var pas = driver.FindElement(_pas);

            var logBtn = driver.FindElement(_loginBtn);
            IN.SendKeys("disod49294@aramidth.com");
            pas.SendKeys("a933e3af");

            logBtn.Click();

            var emailCheck = driver.FindElement(_emailCheck).Text;

            Assert.AreEqual(emailCheck, "disod49294@aramidth.com", "WRONG");
        }

        [Test]
        public void Test2()
        {
            var link = driver.FindElement(_link);
            link.Click();
            Assert.IsTrue(driver.Url.Contains("https://veliki.com.ua/dir_stats.htm"), "Something Wrong");


        }


        [Test]
        public void Test3() // регистрация и фейковая почта
        {
            driver.Navigate().GoToUrl("https://veliki.com.ua/?base=client");
            System.Threading.Thread.Sleep(1500);
            var regName = driver.FindElement(_registrationName);
            var regSecondName = driver.FindElement(_registrationSecondName);
            var regSurname = driver.FindElement(_registrationSurname);
            var regEmail = driver.FindElement(_registrationEmail);

            var regButton = driver.FindElement(_registrationButton);

            var expectedErrorMessage = "Вы не верно указали Вашу электронную почту!";

            regName.SendKeys("Abaa");
            regSecondName.SendKeys("Abaa");
            regSurname.SendKeys("Abaa");
            regEmail.SendKeys("awdawdawdad");

            regButton.Click();
            var errorMessage = driver.FindElement(_errorMessage).Text;
            System.Threading.Thread.Sleep(500);

            Assert.AreEqual(expectedErrorMessage, errorMessage);

        }


        [Test]
        public void Test4()
        {
            var cartButton = driver.FindElement(_cartButton);

            var ExpectedMessage = "Ваша корзина пуста!";
            cartButton.Click();
            cartButton.Click();

            System.Threading.Thread.Sleep(1000);
            var cartMessafe = driver.FindElement(_cartMessage).Text;

            Assert.AreEqual(ExpectedMessage, cartMessafe);

        }


        [Test]
        public void Test5() // по линку
        {
            driver.Navigate().GoToUrl("https://veliki.com.ua/dir_press-exercise-machines.htm");
            //var anyLink = driver.FindElement(_anyLink);
           // anyLink.Click();
            System.Threading.Thread.Sleep(500);
            Assert.IsTrue(driver.Url.Contains("https://veliki.com.ua/dir_press-exercise-machines.htm"), "Something Wrong");
        }


        [TearDown]
        public void TearDown() // после теста 
        {
            driver.Quit();
        }
    }
}
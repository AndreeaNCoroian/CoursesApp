using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTesting
{
    [TestFixture]
    public class Chrome_sample_test
    {

        private IWebDriver driver;
        public string homeURL;


        [Test(Description = "Check CoursesApp Homepage for Sign in Link")]
        public void Login_is_on_home_page()
        {


            homeURL = "https://localhost:44303/";
            driver.Navigate().GoToUrl(homeURL);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => driver.FindElement(By.XPath("//a[@href='https://localhost:44303/']")));
            IWebElement element = driver.FindElement(By.XPath("//a[@href='https://localhost:44303/']"));
            Assert.AreEqual("Sign In", element.GetAttribute("text"));


        }

        [TearDown]
        public void TearDownTest() //is executed after each test
        {
            driver.Close();
        }

        [SetUp] //is executed before each test
        public void SetupTest()
        {
            homeURL = "https://localhost:44303/";
            driver = new ChromeDriver();

        }


    }
}

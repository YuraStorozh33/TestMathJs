using NUnit.Framework;
using OpenQA.Selenium;
using TestMathJs;
using System;
using System.Threading;

Tests test = new Tests();
test.Setup();
test.Test1("3+4","7",1);
test.TearDown();
test.Setup();
test.Test1("2*43(34-25)", "774", 2);
test.TearDown();
test.Setup();
test.Test1("1.2 * (2 + 4.5)", "7,8", 3);
test.TearDown();
test.Setup();
test.Test1("9 / 3 + 2i", "3 + 2i", 4);
test.TearDown();

namespace TestMathJs
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _mathInputButton = By.XPath("//input[@type='text']");
        private readonly By _findResultButton = By.XPath("//a[@id='link']");
        private readonly By _Result = By.XPath("//body[text()]");

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://api.mathjs.org/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1(string actual, string expected,byte numberoftest)
        {

            var math = driver.FindElement(_mathInputButton);         //вікно для вводу значень
            math.Clear();                                            //очистка цього вікна від значень
            Thread.Sleep(500);
            math.SendKeys(actual);                                   //ввід значень
            Thread.Sleep(500);
            var findResult = driver.FindElement(_findResultButton);  //клік для вирішення прикладу
            findResult.Click();
            Thread.Sleep(500);
            var result = driver.FindElement(_Result).Text;
            Assert.AreEqual(expected, result);                        //перевірка значень
            Console.WriteLine($"Successful TEST {numberoftest}");
        }
      
        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}
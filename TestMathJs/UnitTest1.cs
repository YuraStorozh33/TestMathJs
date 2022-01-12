using NUnit.Framework;
using OpenQA.Selenium;
using TestMathJs;
using System;
using System.Threading;

Tests test = new Tests();
test.Setup();
test.Test1();




namespace TestMathJs
{

    public class Tests
    {
        private IWebDriver driver;
        private readonly By _mathInputButton = By.XPath("//input[@type='text']");
        private readonly By _findResultButton = By.XPath("//a[@id='link']");
        private readonly By _Result = By.XPath("//body[text()]");
        private string exampleactual = "25+1777";
        private string exampleexpected = "1802";


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://api.mathjs.org/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {

            var math = driver.FindElement(_mathInputButton);
            math.Clear();
            math.SendKeys(exampleactual);
            Thread.Sleep(500);
            var findResult = driver.FindElement(_findResultButton);
            findResult.Click();
            var result = driver.FindElement(_Result);
            var number = result.Text.Clone();
            Console.WriteLine($"Number is {number}");
            Assert.AreEqual(exampleexpected, number);
        }
      
        
        [TearDown]
        public void TearDown()
        {

        }
    }
}
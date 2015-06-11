using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace FFFrontend.Tests
{
    [TestClass]
    public class HomeTest
    {
        private ChromeDriver _chromeDriver;
        private ChromeDriverService _service;
        private ICapabilities _capability;

        [TestMethod]
        public void TestHomePage()
        {
            _service = ChromeDriverService.CreateDefaultService(@"C:\Users\T.Nle\Desktop\FFBackEnd\WebDrivers");
            _capability = new ChromeOptions().ToCapabilities();

            _chromeDriver = new ChromeDriver(_service);

            _chromeDriver.Navigate().GoToUrl(@"http://ff-team.com/wp-admin");

            Thread.Sleep(5000);
            _chromeDriver.FindElementById("user_login").SendKeys("testlogin");
            _chromeDriver.FindElementById("user_pass").SendKeys("123456");
            Thread.Sleep(3000);
            _chromeDriver.FindElementById("wp-submit").Click();
        }

        [TestCleanup]
        public void TearDown()
        {
            _chromeDriver.Quit();
        }
    }
}

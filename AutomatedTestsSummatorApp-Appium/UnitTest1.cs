using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;

namespace AutomatedTestsSummatorApp_Appium
{
    public class Tests
    {
        private const string AppiumServerUri = "http://[::1]:4723/wd/hub";
        private const string SummatorAppPath = @"D:\WindowsFormsApp.exe";
        //private AppiumLocalService appiumLocalService;
        private WindowsDriver<WindowsElement> driver;

        [OneTimeSetUp]
        public void Setup()
        {
            //appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //appiumLocalService.Start();
            var appiumOptions = new AppiumOptions()
            {
                PlatformName = "Windows"
            };
            appiumOptions.AddAdditionalCapability("app", SummatorAppPath);
            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServerUri), appiumOptions);
        
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
           // appiumLocalService.Dispose();
        }


        [Test]
        public void TestSummator()
        {
            var firstNumField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            firstNumField.Clear();
            firstNumField.SendKeys("15");
            var secondNumField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            secondNumField.Clear();
            secondNumField.SendKeys("8,5");
            var calcbtn = driver.FindElementByAccessibilityId("buttonCalc");
            calcbtn.Click();
            var resulField = driver.FindElementByAccessibilityId("textBoxSum");
            Assert.AreEqual("23,5", resulField.Text);
        }
    }
}
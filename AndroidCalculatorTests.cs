using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidAppiumTests
{
    public class AndroidCalculatorTests
    {
        private AndroidDriver<AndroidElement> driver;
        private const string appiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"E:\\SoftUni\\QA-Automation-Front-End\\Mobile App\\com.example.androidappsummator.apk";
        private AppiumOptions options;

        private AndroidElement firstNum;
        private AndroidElement secondNum;
        private AndroidElement resultField;
        private AndroidElement CalcButton;

        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumUrl), options);

            firstNum = driver.FindElementById("com.example.androidappsummator:id/editText1");
            secondNum = driver.FindElementById("com.example.androidappsummator:id/editText2");
            resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            CalcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
        }

        [OneTimeTearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_CalculateTwoPositiveNumbers()
        {
            firstNum.Clear();
            secondNum.Clear();
            firstNum.SendKeys("5");
            secondNum.SendKeys("15");
            CalcButton.Click();
            string result = resultField.Text;

            Assert.That(result, Is.EqualTo("20"));
        }


        [Test]
        public void Test_CalculateInvalidValues()
        {
            firstNum.Clear();
            secondNum.Clear();
            firstNum.SendKeys("5");
            secondNum.SendKeys("alabala");
            CalcButton.Click();
            string result = resultField.Text;

            Assert.That(result, Is.EqualTo("error"));
        }
    }
}
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpringerSearchFunctionality.Steps
{
    public class TestFixtureBase
    {
        protected IWebDriver CurrentDriver { get; set; }
        //{
        //    get { return new InternetExplorerDriver(); }
        //    set => CurrentDriver = value;
        //}

        [SetUp]
        public void Test_Setup()
        {
            CurrentDriver = new ChromeDriver();
        }



        [TearDown]
        public void Test_Teardown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed && CurrentDriver is ITakesScreenshot)
                {
                    ((ITakesScreenshot)CurrentDriver).GetScreenshot().SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ScreenshotImageFormat.Jpeg);
                }
            }
            catch { }   // null ref exception occurs from accessing TestContext.CurrentContext.Result.Status property

            try
            {
                CurrentDriver.Quit();
            }
            catch { }
        }
    }
}

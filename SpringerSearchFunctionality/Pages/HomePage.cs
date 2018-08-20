using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace SpringerSearchFunctionality.Pages
{
    public class HomePage
    {
        public static string HomePageUrl => "https://link.springer.com/";

        public IWebDriver Driver { get; set; }

        [FindsBy(How = How.TagName, Using = "body")]
        public IWebElement BodyTag;

        [FindsBy(How = How.ClassName, Using = "search-submit")]
        public IWebElement SearchButton;

        [FindsBy(How = How.Name, Using = "query")]
        public IWebElement SearchTextbox;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Goto(string homePageUrl)
        {
            Driver.Navigate().GoToUrl(homePageUrl);
            var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            webDriverWait.Until(d => d.FindElement(By.TagName("body")));
        }

        public void TypeUserInputToTextbox(string keyword)
        {
            SearchTextbox.Clear();
            SearchTextbox.SendKeys(keyword);
            BodyTag.Click();
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public void CheckResultsAndKeyword(string resultWord)
        {
            Assert.IsTrue(Driver.Title.Equals("Search Results - Springer"));
            Assert.IsTrue(Driver.Url.Equals($"https://link.springer.com/search?query={resultWord}"));
        }
    }
}

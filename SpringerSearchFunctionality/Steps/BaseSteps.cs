using OpenQA.Selenium;
using SpringerSearchFunctionality.Pages;
using TechTalk.SpecFlow;

namespace SpringerSearchFunctionality.Steps
{
    public class BaseSteps : TestFixtureBase
    {
        protected HomePage NextPage { set => CurrentPage = value; }

        protected HomePage CurrentPage
        {
            get => (HomePage)ScenarioContext.Current["CurrentPage"];
            set => ScenarioContext.Current["CurrentPage"] = value;
        }

        [BeforeScenario("UI")]
        public void BeforeScenario()
        {
            if (!ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Setup();
                ScenarioContext.Current.Add("CurrentDriver", CurrentDriver);
            }
            else
            {
                CurrentDriver = (IWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
        }

        [AfterScenario("UI")]
        public void AfterScenario()
        {
            if (!ScenarioContext.Current.ContainsKey("CurrentDriver")) return;

            Test_Teardown();
            ScenarioContext.Current.Remove("CurrentDriver");
        }
    }
}

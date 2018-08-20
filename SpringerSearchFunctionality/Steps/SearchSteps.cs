using SpringerSearchFunctionality.Pages;
using TechTalk.SpecFlow;

namespace SpringerSearchFunctionality.Steps
{
    [Binding]
    public class SearchSteps : BaseSteps
    {
        [Given(@"That I am on home page and have a word to search")]
        public void GivenThatIAmOnHomePageAndHaveAWordToSearch()
        {
            CurrentPage = new HomePage(CurrentDriver);
            CurrentPage.Goto(HomePage.HomePageUrl);
        }

        [When(@"I type ""(.*)"" in search box")]
        public void WhenITypeInSearchBox(string typeWord)
        {
            CurrentPage.TypeUserInputToTextbox(typeWord);
        }

        [When(@"Click search button")]
        public void WhenClickSearchButton()
        {
            CurrentPage.ClickSearchButton();
        }

        [Then(@"Books related to ""(.*)"" will appear in search result")]
        public void ThenBooksRelatedToWillAppearInSearchResult(string resultWord)
        {
            CurrentPage.CheckResultsAndKeyword(resultWord);
        }
    }
}

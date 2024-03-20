using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace amazonProjectBDD
{
    [Binding]
    public class AmazonShoppingSteps
    {
        private IWebDriver _driver;
        private AmazonHomePage _amazonHomePage;
        private AmazonCartPage _amazonCartPage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new();
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-popup-blocking");

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _amazonHomePage = new AmazonHomePage(_driver);
            _amazonCartPage = new AmazonCartPage(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [Given(@"I am on the Amazon home page")]
        public void GivenIAmOnTheAmazonHomePage()
        {
            _amazonHomePage.NavigateToHomePage("https://www.amazon.com/");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            _amazonHomePage.SearchForItem(searchTerm);
        }

        [When(@"I add the corresponding item to the cart")]
        public void WhenIAddTheCorrespondingItemToTheCart()
        {
            _amazonHomePage.ClickOnFirstSearchResult();
            _amazonHomePage.AddItemToCart();
        }

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            _amazonHomePage.NavigateToCart();
        }

        [Then(@"I validate the correct item and amount is displayed")]
        public void ThenIValidateTheCorrectItemAndAmountIsDisplayed()
        {
            string itemName = _amazonCartPage.GetCartItemName();
            string itemPrice = _amazonCartPage.GetCartItemPrice();

                Assert.That(itemName.Contains("TP-Link N450 WiFi Router - Wireless Internet Router for Home (TL-WR940N)"), "Item name validation failed.");
       }
    }
}

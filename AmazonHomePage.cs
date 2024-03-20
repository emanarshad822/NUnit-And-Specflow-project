using OpenQA.Selenium;

namespace amazonProjectBDD
{
    public class AmazonHomePage
    {
        private readonly IWebDriver _driver;

        // Locators
        private const string SearchBoxId = "twotabsearchtextbox";
        private const string FirstSearchResultCssSelector = "span[data-component-type='s-search-results'] div[data-asin][data-index='0']";
        private const string AddToCartButtonId = "add-to-cart-button";
        private const string CartIconId = "nav-cart";

        public AmazonHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToHomePage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void SearchForItem(string searchTerm)
        {
            _driver.FindElement(By.Id(SearchBoxId)).SendKeys(searchTerm + Keys.Enter);
        }

        public void ClickOnFirstSearchResult()
        {
            _driver.FindElement(By.CssSelector(FirstSearchResultCssSelector)).Click();
        }

        public void AddItemToCart()
        {
            _driver.FindElement(By.Id(AddToCartButtonId)).Click();
        }

        public void NavigateToCart()
        {
            _driver.FindElement(By.Id(CartIconId)).Click();
        }
    }
}

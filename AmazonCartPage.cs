using OpenQA.Selenium;

namespace amazonProjectBDD
{
    public class AmazonCartPage
    {
        private readonly IWebDriver _driver;

        // Locators
        private const string ItemNameCssSelector = "span[data-action='cart-update-text']";
        private const string ItemPriceCssSelector = "span[data-action='cart-update-price']";

        public AmazonCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetCartItemName()
        {
            return _driver.FindElement(By.CssSelector(ItemNameCssSelector)).Text;
        }

        public string GetCartItemPrice()
        {
            return _driver.FindElement(By.CssSelector(ItemPriceCssSelector)).Text;
        }
    }
}

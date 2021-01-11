using OpenQA.Selenium;

namespace AnswerDigitalMain.ShoppingBasket
{
    public class ShoppingBasketReferences
    {
        private readonly IWebDriver driver;

        public ShoppingBasketReferences(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public IWebElement deleteIcon
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".icon-trash"));
            }
        }


        public IWebElement OrderDetails
        {
            get
            {
                return this.driver.FindElement(By.Id("order-detail-content"));
            }
        }

        public IWebElement CartEmptyMessage
        {
            get
            {
                return this.driver.FindElement(By.XPath("//p[@class='alert alert-warning']"));
            }
        }

    }
}

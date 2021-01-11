using OpenQA.Selenium;

namespace AnswerDigitalMain.HomePage
{
    public class HomePageReferences
    {

        private readonly IWebDriver driver;

        public HomePageReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AddToCartButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]"));
            }
        }

        public IWebElement ProceedToCheckoutButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//span[contains(.,'Proceed to checkout')]"));
            }
        }

        public IWebElement FirstProduct
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]"));
            }
        }

        public IWebElement WomenSubCategory
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("ul.sf-menu > li:nth-of-type(1) > .submenu-container"));
            }
        }

        public IWebElement WomenNav
        {
            get
            {
                // return this.driver.FindElement(By.)
                return this.driver.FindElement(By.LinkText("WOMEN"));
            }
        }

        public IWebElement Summeritems
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".ac_results"));
            }
        }



    }
}

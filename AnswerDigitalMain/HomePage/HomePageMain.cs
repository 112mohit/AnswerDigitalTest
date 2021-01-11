using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;


namespace AnswerDigitalMain.HomePage
{
    public class HomePageMain
    {
        private IWebDriver driver;
        public static string URL = "http://automationpractice.com/index.php";

        protected HomePageReferences homepageReferences
        {
            get
            {
                return new HomePageReferences(this.driver);
            }
        }

        public HomePageMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToTheWebsite()
        {
            this.driver.Navigate().GoToUrl(URL);
        }

        //Adding item to the cart 
        public void AddItemToCart()
        {
            NavigateToTheWebsite();
            Actions action = new Actions(driver);
            action.MoveToElement(homepageReferences.FirstProduct).Perform();
            action.MoveToElement(homepageReferences.AddToCartButton).Click().Perform();
            Thread.Sleep(2000);
            this.homepageReferences.ProceedToCheckoutButton.Click();
        }

        //Navigate to womens category 
        public void NavWomenCategory()
        {
            NavigateToTheWebsite();
            Actions action = new Actions(driver);
            action.MoveToElement(homepageReferences.WomenNav).Perform();

        }


    }
}

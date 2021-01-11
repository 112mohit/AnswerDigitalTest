using OpenQA.Selenium;
using System;


namespace AnswerDigitalMain.ShoppingBasket
{

   
    public class ShoppingBasketMain
    {

        private IWebDriver driver;

        public ShoppingBasketReferences shoppingbasketReferences
        {
            get
            {
                return new ShoppingBasketReferences(this.driver);
            }
        }

        public ShoppingBasketMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Boolean to check if element is present 
        public Boolean iselementPresent(IWebElement element )
        {
           
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;             
            }

           
            
        }




    }
}

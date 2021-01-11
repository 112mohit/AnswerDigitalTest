using OpenQA.Selenium;

namespace AnswerDigitalMain.Account
{
    public class AccountReferences
    {

        private readonly IWebDriver driver;

        public AccountReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AccountPage
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".login"));
            }
        }

        public IWebElement EmailAddressField
        {
            get
            {
                return this.driver.FindElement(By.Id("email_create"));
            }
        }

        public IWebElement CreateAccountButton
        {
            get
            {
                return this.driver.FindElement(By.Id("SubmitCreate"));
            }
        }

        public IWebElement FormValidationOk
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".form-ok"));
            }
        }

        public IWebElement FirstName
        {
            get
            {
                return this.driver.FindElement(By.Id("customer_firstname"));
            }
        }


        public IWebElement LastName
        {
            get
            {
                return this.driver.FindElement(By.Id("customer_lastname"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Id("passwd"));
            }
        }

        public IWebElement AddressFirstName
        {
            get
            {
                return this.driver.FindElement(By.Id("firstname"));
            }
        }

        public IWebElement AddressLastName
        {
            get
            {
                return this.driver.FindElement(By.Id("lastname"));
            }
        }

        public IWebElement Address
        {
            get
            {
                return this.driver.FindElement(By.Id("address1"));
            }
        }

        public IWebElement City
        {
            get
            {
                return this.driver.FindElement(By.Id("city"));
            }
        }

        public IWebElement State
        {
            get
            {
                return this.driver.FindElement(By.Id("id_state"));
            }
        }


        public string Postcode(string postcode)
        {

            this.driver.FindElement(By.Id("postcode")).SendKeys(postcode);
            return null;

        }

        public IWebElement Country
        {
            get
            {
                return this.driver.FindElement(By.Id("id_country"));
            }
        }

        public IWebElement MobilePhone
        {
            get
            {
                return this.driver.FindElement(By.Id("phone_mobile"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                return this.driver.FindElement(By.Id("submitAccount"));
            }
        }

        public IWebElement InvalidInfoError
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
            }
        }

        public IWebElement PageHeading
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='center_column']/h1"));
            }
        }

        public IWebElement AccountName
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("a.account > span"));
            }
        }

    }
}

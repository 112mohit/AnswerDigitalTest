using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AnswerDigitalMain.Account
{
    public class Names
    {
        public static string firstName = "UserFirst";
        public static string lastName = "UserLast";
    }

    public class AccountMain
    {

        private IWebDriver driver;


        protected AccountReferences accountReferences
        {
            get
            {
                return new AccountReferences(this.driver);
            }
        }

        public AccountMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToCreateAccountPage()
        {
            accountReferences.AccountPage.Click();
        }

        public void CreateAccount()
        {
            //Random email Address creation. So new email is generated everytime. 
            Random ran = new Random();
            int i = ran.Next(0, 10000);
            int j = ran.Next(0, 10000);
            accountReferences.EmailAddressField.SendKeys("user10" + j + "@test" + i + ".com");
            this.driver.FindElement((By.CssSelector("[for='email_create']"))).Click(); //Clicking away from the field 

        }
        public void Password()
        {
            accountReferences.Password.SendKeys("Pass@Pass");
        }

        public void RegisterButtonClick()
        {
            accountReferences.RegisterButton.Click();
        }


        //User Registration 
        public void UserRegistration()
        {

            accountReferences.FirstName.SendKeys(Names.firstName);  //Sending first name 
            accountReferences.LastName.SendKeys(Names.lastName);   //Sending last name 
            Password();        
            accountReferences.Address.SendKeys("Street 1");
            accountReferences.City.SendKeys("City 1");

            //Selecting second state by Index
            SelectElement stateSelect = new SelectElement(accountReferences.State);
            stateSelect.SelectByIndex(2);
           
            //Selecting Country by text
            SelectElement countrySelect = new SelectElement(accountReferences.Country);
            countrySelect.SelectByText("United States");
            
            accountReferences.MobilePhone.SendKeys("1234567654");
            //Registration button click 
            RegisterButtonClick();

        }




    }
}

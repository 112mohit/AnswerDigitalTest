using AnswerDigitalMain.Account;
using AnswerDigitalMain.HomePage;
using AnswerDigitalMain.ShoppingBasket;
using AnswerDigitalMain.Stores;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace AnswerDigitalUnitTests
{
    [TestFixture]
    public class UnitTest
    {
        //initialization
        public IWebDriver driver;
        public ShoppingBasketMain shoppingBasket;
        public HomePageMain homepageMain;
        public AccountMain accountMain;
        public StoresMain storeMain;


        protected ShoppingBasketReferences shoppingbasketReferences
        {
            get
            {
                return new ShoppingBasketReferences(this.driver);
            }
        }

        protected HomePageReferences homepageReferences
        {
            get
            {
                return new HomePageReferences(this.driver);
            }
        }

        protected AccountReferences accountReferences
        {
            get
            {
                return new AccountReferences(this.driver);
            }
        }

        protected StoresReferences storeReferences
        {
            get
            {
                return new StoresReferences(this.driver);
            }
        }


        //OneTime Setup 
        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            this.shoppingBasket = new ShoppingBasketMain(this.driver);
            this.homepageMain = new HomePageMain(this.driver);
            this.accountMain = new AccountMain(this.driver);
            this.storeMain = new StoresMain(this.driver);
        }

        //First User Story. First Acceptance Criteria test.
        [Test]
        public void UserStoryOne()
        {
            homepageMain.AddItemToCart();  //Calling Add to cart method. 

            //Try and Catch and IF statement to check if delete button is present. If present then Checking other two conditions 
            try
            {
                var deleteButton = shoppingbasketReferences.deleteIcon; //Finding the Trash icon 


                if (deleteButton.Displayed) //If delete button is displayed
                {
                    this.shoppingbasketReferences.deleteIcon.Click(); //Deleting the item 

                    try
                    {
                        Thread.Sleep(3000);
                        if (shoppingbasketReferences.OrderDetails.Displayed) //Verifying if order detials are displayed. If displayed then fail. 
                        {
                            Assert.Fail("Delete icon is displayed but item is not removed from the cart.");
                        }

                    }
                    catch (NoSuchElementException orderdetailsnotDisplayed) //Handling with exception And if Shopping cart is empty message is displayed then pass otherwise fail
                    {
                        if (shoppingbasketReferences.CartEmptyMessage.Text.Contains("Your shopping cart is empty."))
                        {
                            Assert.Pass("Shopping Cart had a delete button. Item was then removed from the Cart and Then your shopping cart is empty message is displayed.");
                        }
                        else
                        {
                            Assert.Fail("Order details are not displayed, but Shopping cart empty banner is not displayed.");
                        }
                    }

                }
                else //If Button is present but other two conditions are not met then Failing the case. 
                {
                    Assert.Fail("Delete Button is Displayed but other two conditions were not met. Case Failed");
                }
            }
            catch (NoSuchElementException cartemptyiconnotVisible) //Handling the exception when delete icon is not present and failing the case. 
            {
                Assert.Fail("Shopping Cart is Empty, Delete Icon is not visible.");
            }

        }

        [Test]
        public void UserStoryTwo()
        {
            homepageMain.NavWomenCategory();  //Navigate tO womens Tab 

            Thread.Sleep(3000);
            //If sub menu container displayed then pass otherwise fail 
            try
            {
                Thread.Sleep(3000);
                var submenudisplayed = driver.FindElement(By.CssSelector("ul.sf-menu > li:nth-of-type(1) > .submenu-container"));
                if (submenudisplayed.Displayed == true)
                {
                    try
                    {
                        Thread.Sleep(4000);
                        this.driver.FindElement(By.Id("search_query_top")).Click();

                        Thread.Sleep(2000);

                        //Sending the Keys 
                        this.driver.FindElement(By.Id("search_query_top")).SendKeys("Summer");

                        Thread.Sleep(9000);


                        var searchedlist = driver.FindElement(By.CssSelector("div.ac_results > ul"));
                        IList<IWebElement> links = searchedlist.FindElements(By.TagName("li"));
                        var searchedreturnedList = links.Count();


                        List<string> searchItems = new List<string>();
                        //For loop to go through the search items list and then adding them to the list. 
                        for (int items = 1; items <= searchedreturnedList; items++)
                        {
                            var resultitems = this.driver.FindElement(By.XPath("//div[@class='ac_results']//li[" + items + "]")).Text.Split('>').Last().Trim();
                            searchItems.Add(resultitems);
                        }

                        //Prinitng the search items 
                        searchItems.ForEach(Console.WriteLine);


                        this.driver.FindElement(By.XPath("//*[@id='searchbox']/button")).Click();
                        Thread.Sleep(2000);

                        List<string> displayedItems = new List<string>();
                        //For loop to go through the displayed items and adding them to a list 
                        for (int i = 1; i <= searchedreturnedList; i++)
                        {
                            var items = this.driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[" + i + "]/div/div[2]/h5/a")).Text;
                            displayedItems.Add(items);

                        }

                        //Priniting the search result items 
                        displayedItems.ForEach(Console.WriteLine);

                        //If Searched Items and search results are same. Then pass else fail the case
                        if (searchItems.SequenceEqual(displayedItems))
                        {
                            Assert.Pass("Test Pass, Searched items and Displayed results are same ");
                        }

                        else
                        {
                            Assert.Fail("Test Failed, as Test result are not same as what was searched for.");
                        }

                    }

                    catch (IgnoreException)
                    {

                    }
                }
                 else{
                    Assert.Fail("Test Failed, Sub menu was not displayed.");
                }

            }
            catch (IgnoreException)
            {
                Assert.Fail("Test Fail, Sub menu was not displayed, Test Failed.");
            }




        }



        [Test]
        public void UserStoryFour()
        {
            homepageMain.NavigateToTheWebsite(); //Navigation to the website
            accountMain.NavigateToCreateAccountPage(); //Navigate to the Sign in page
            accountMain.CreateAccount(); //Create account

            try
            {
                Thread.Sleep(2000);  //If Form validation is done then click on Create account button. 
                Assert.IsTrue(accountReferences.FormValidationOk.Displayed, "Validation is done for the valid info");
                accountReferences.CreateAccountButton.Click();
            }
            catch (Exception)
            {
                Assert.Fail("Validation is not done for valid data , Case failed "); //If validation is not passed then fail 
            }

            Thread.Sleep(3000);
            accountReferences.Postcode("2222"); //Entering invalid data to see if validation message is displayed.
            accountMain.UserRegistration(); //Filling in all other details 
            try
            {
                Thread.Sleep(2000);
                //Checking if error is displayed and message contains invalid. 
                Assert.IsTrue(accountReferences.InvalidInfoError.Displayed && accountReferences.InvalidInfoError.Text.Contains("invalid"), "Invalid info displayed an error message. ");
                accountReferences.Postcode("2"); //Filling in the correct info now 
                accountMain.Password();
                accountMain.RegisterButtonClick();
                //If still there is any error displayed  then fail the case 
                if (accountReferences.InvalidInfoError.Displayed)
                {

                    Assert.Fail(accountReferences.InvalidInfoError.Text); //Display the error message in console and fail the case. 
                    Assert.Fail("There are still some invalid information. Please enter correct info to continue.");

                }
                else
                {
                    Assert.Pass("Validation of the invalid data done."); //Else pass 
                }
            }
            catch (Exception ee)
            {
                /*Handling the exception when error message is not displayed and user account is created. 
                And checking if the user is on my account page and username is dislayed on top right */
                if (accountReferences.PageHeading.Text.Contains("MY ACCOUNT") && accountReferences.AccountName.Text.Contains(Names.firstName + " " + Names.lastName))
                {
                    Assert.Pass("All Acceptance Criteria Met. Account page is displayed and Username is displayed on top right");

                }
                else
                {
                    Assert.Fail("USer is not on the account page or username is not dislayed");
                }
            }


        }


        [Test]
        public void USerStoryFive()
        {
            homepageMain.NavigateToTheWebsite(); //Navigation to the website
            storeMain.NavigateToOurStoresPage(); //Navigate to Our Stores page
            Thread.Sleep(2000);
            storeMain.gototheStore(); //Scrolll to the Pembroke Pines store

            //If Scrolled store conatins Pembroke pines then pass and take the screenshot 
            if ((storeReferences.PenbrookeStoreMapArea).Text.Contains("Pembroke Pines"))
            {
                Thread.Sleep(10000);
                storeMain.Capture("Pembroke Pines"); //Take Screen shot 
                Assert.Pass("User has Scrolled to Pembroke Pines and screenshot is Taken");
            }
            else
            {
                Assert.Fail("User has Scrolled in the map but not to the correct store.");
            }

        }


        [OneTimeTearDown]
        public void TestTearDown()
        {
            this.driver.Quit();
        }



    }
}

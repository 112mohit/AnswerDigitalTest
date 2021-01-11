using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;


namespace AnswerDigitalMain.Stores
{

    //Initialzation
    public class StoresMain
    {

        private IWebDriver driver;


        protected StoresReferences storesReferences
        {
            get
            {
                return new StoresReferences(this.driver);
            }
        }

        public StoresMain(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Screenshot Taking method
        public string Capture(string name)
        {
            ITakesScreenshot takeScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takeScreenshot.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));  
            string projectPath = new Uri(actualPath).LocalPath;
            string finalpth = projectPath + "Screenshots\\" + name + " " + DateTime.Now.ToString("dd-MM-yyyy HH-mm") + ".png";  //Adding the Date and Time to the screenshot 
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);  //Saving the screenshot as png format 
            return localpath;
        }

        //Navigate to stores page
        public void NavigateToOurStoresPage()
        {
            storesReferences.OurStoreButton.Click();
            storesReferences.GooglePopUpDismiss.Click();
        }

        //Scroll to the store 
        public void gototheStore()
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(901, 579).DoubleClick().Perform();
            storesReferences.ZoomButton.Click();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()",storesReferences.PembrookeStore);

        }
    }
}

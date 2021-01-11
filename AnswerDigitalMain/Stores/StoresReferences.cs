using OpenQA.Selenium;

namespace AnswerDigitalMain.Stores
{
    public class StoresReferences
    {

        private readonly IWebDriver driver;

        public StoresReferences(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement StoreLocation
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[@class='gm-style']//div[3]/div[3]"));
            
            }
        }


        public IWebElement OurStoreButton
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("a[title='Our stores']"));
            }
        }

        public IWebElement GooglePopUpDismiss
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".dismissButton"));
            }
        }

        public IWebElement ZoomButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[@class='gmnoprint gm-bundled-control gm-bundled-control-on-bottom']/div[3]//button[1]"));
            }
        }

        public IWebElement PembrookeStore
        {
            get
            {
                return driver.FindElement(By.XPath("//div[@class='gm-style']//div[3]/div[3]"));
            }
        }

        public IWebElement PenbrookeStoreMapArea
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='map']/div/div/div[1]/div[3]/div/div[4]/div/div/div/div/div"));
            }
        }
    }
}

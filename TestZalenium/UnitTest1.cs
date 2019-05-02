using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;

namespace TestZalenium
{
    [TestClass]
    public class UnitTest1
    {
        // please pass path of your zalenium server
        private const string remotePath = "http://10.105.4.160:4444/wd/hub";

        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions copt = new ChromeOptions();
            IWebDriver driver = new RemoteWebDriver(new Uri(remotePath), copt);
            //this url is public test url for your reference
            driver.Url = "https://encodable.com/uploaddemo/";
            IWebElement uploadFile = driver.FindElement(By.Id("uploadname1"));
            uploadFile.Click();
            Thread.Sleep(5000);
            // In place of home/seluser/deploymentdir you can pass you local dir mounted and pass any file , i am passing C133780.svg. 
            UploadFile("/home/seluser/deploymentdir/C133780.svg");
            Thread.Sleep(15000);
            driver.FindElement(By.Id("uploadbutton")).Click();
        }

        public void UploadFile(string filePath)
        {
            SendKeys.SendWait(filePath);
            SendKeys.SendWait(@"{Enter}");
        }
    }
}

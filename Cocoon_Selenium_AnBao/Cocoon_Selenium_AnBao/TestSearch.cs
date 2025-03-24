using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace Cocoon_Selenium_AnBao
{

    [TestClass]
    public class TestSearch
    {
        [TestMethod]
        public void Test_Search_CatalogAnBao()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cocoonvietnam.com/");

            // tìm button search
            IWebElement search = driver.FindElement(By.XPath("//*[@id=\"navbar\"]/div[3]/nav/div[1]/div/div"));

            search.Click();

            Thread.Sleep(1000); // phải chờ để nhận element bên dưới

            // bắt place holder tìm kiếm
            IWebElement input = driver.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(2) > div.hidden.lg" +
                "\\:block > nav > div:nth-child(2) > div > div > form > div > div > input"));
            input.SendKeys("xx");

            string err = "Không tìm thấy";
            string mess = "";
            bool isSearch = true;
            
            Thread.Sleep(3000);

                // nếu bắt được thẻ p nội dung "Gợi ý tìm kiếm" ==> tìm kiếm thất bại
            IWebElement notification = driver.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(2) > div.hidden.lg" +
                "\\:block > nav > div:nth-child(2) > div > div > div.mt-4.animate-fade-in > p"));
            mess = notification.Text.ToString();
            if (mess == "Gợi ý tìm kiếm:")
                isSearch = false;
            else
                isSearch = true;
            Assert.IsTrue(isSearch, err);
        }
    }
}

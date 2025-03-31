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
    public class TestSearch_AnBao
    {
        [TestMethod]
        // Case1: Tìm thấy sản phẩm có chứa từ khóa
        // Khi nhập từ khóa sẽ nhận được các sản phẩm liên quan
        public void TC9_TestSearch_AnBao()
        {
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            // tìm button search
            IWebElement search_AnBao = driver_AnBao.FindElement(By.XPath("//*[@id=\"navbar\"]/div[3]/nav/div[1]/div/div"));

            search_AnBao.Click();
            // phải chờ để nhận element bên dưới
            Thread.Sleep(1000); 

            // bắt place holder tìm kiếm ==> truyền từ khóa vào
            IWebElement input_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(2) > div.hidden.lg" +
                "\\:block > nav > div:nth-child(2) > div > div > form > div > div > input"));
            input_AnBao.SendKeys("tẩy");

         
            string mess_AnBao = "";
            
            Thread.Sleep(3000);

                // nếu bắt được thẻ p nội dung "Ý bạn là" ==> tìm kiếm thành công ==> pass
            IWebElement notification_AnBAo = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(2) > div.hidden.lg" +
                "\\:block > nav > div:nth-child(2) > div > div > div > p"));
            mess_AnBao = notification_AnBAo.Text.ToString();
            if (mess_AnBao == "Ý bạn là:")
            {
                Assert.IsTrue(true);
                Console.WriteLine("Pass");
            }
            else
            {
                Assert.IsTrue(false);
                Console.WriteLine("Failed");
            }    
        }

        [TestMethod]
        // Case2: Không tìm thấy sản phẩm có chứa từ khóa truyền vào
        // Khi truyền vào từ khóa sẽ không nhận được các sản phẩm liên quan
        public void TC10_TestSearch_AnBao()
        {
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            // tìm button search
            IWebElement search_AnBao = driver_AnBao.FindElement(By.XPath("//*[@id=\"navbar\"]/div[3]/nav/div[1]/div/div"));

            search_AnBao.Click();
            // phải chờ để nhận element bên dưới
            Thread.Sleep(1000); 

            // bắt place holder tìm kiếm ==> truyền từ khóa vào
            IWebElement input_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(2) > div.hidden.lg" +
                "\\:block > nav > div:nth-child(2) > div > div > form > div > div > input"));
            input_AnBao.SendKeys("aaaa");


            string mess_AnBao  = "";

            Thread.Sleep(3000);

            // nếu bắt được thẻ p nội dung "Gợi ý tìm kiếm" ==> pass
            IWebElement notification_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(2) > div.hidden.lg" +
                "\\:block > nav > div:nth-child(2) > div > div > div.mt-4.animate-fade-in > p"));
            mess_AnBao = notification_AnBao.Text.ToString();
            if (mess_AnBao == "Gợi ý tìm kiếm:")
            {
                Assert.IsTrue(true);
                Console.WriteLine("Pass");
            }
            else
            {
                Assert.IsTrue(false);
                Console.WriteLine("Failed");
            }

        }
    }
}

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cocoon_Selenium_AnBao
{
    [TestClass]
    public class TestLogin
    {
        [TestMethod]
        public void Test_Login_AnBao()
        {
            // SDT: 0326929359
            // pass: Bao12345@
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://cocoonvietnam.com/");

            IWebElement login = driver.FindElement(By.CssSelector("#navbar > div.hidden.lg" +
                "\\:block > nav > div.main-menu__right > div > button:nth-child(1)"));
            login.Click();

            IWebElement tel = driver.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div.phone-input > div > input"));
            tel.SendKeys("0326929359");

            IWebElement password = driver.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div:nth-child(5) > div > input"));
            password.SendKeys("Bao12345@");

            IWebElement button = driver.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5) > " +
                "div > div > form > button"));
            Thread.Sleep(1000); // quan sát dữ liệu được điền

            button.Click();

            Thread.Sleep(1000); // chờ để bắt element bên dưới
            bool isLogin;
            string err = "Đăng nhập không thành công";

            try
            {
                // nếu không bắt được account => ném ngoại lệ đăng nhập không thành công
                IWebElement accont = driver.FindElement(By.CssSelector("#navbar > div.hidden.lg" +
                    "\\:block > nav > div.main-menu__right > div > div > div"));
                isLogin = true;

            }
            catch (NoSuchElementException)
            {

                isLogin = false;
            }
            Assert.IsTrue(isLogin, err);
        }



    }
}


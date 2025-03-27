using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cocoon_Selenium_AnBao
{
    [TestClass]
    public class TestLogin_AnBao
    {
        [TestMethod]
        // Nhập đúng số điện thoại và password
        // Login vào được 
        public void Test_Login__Case1_AnBao()
        {
            // SDT: 0326929359
            // pass: Bao12345@
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            IWebElement login_AnBao = driver_AnBao.FindElement(By.CssSelector("#navbar > div.hidden.lg" +
                "\\:block > nav > div.main-menu__right > div > button:nth-child(1)"));
            login_AnBao.Click();

            // tìm ô số điện thoại ==> truyền vào số điện thoại
            IWebElement tel_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div.phone-input > div > input"));
            tel_AnBao.SendKeys("0326929359");

            // tìm ô password ==> truyền vào password
            IWebElement password_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div:nth-child(5) > div > input"));
            password_AnBao.SendKeys("Bao12345@");
            Thread.Sleep(1000); // quan sát dữ liệu được điền

            // tìm button đăng nhập ==> Click
            IWebElement button_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5) > " +
                "div > div > form > button"));

            button_AnBao.Click();

            Thread.Sleep(1000); // chờ để bắt element bên dưới
        

            try
            {
                // nếu không bắt được account => Pass
                IWebElement account_AnBao = driver_AnBao.FindElement(By.CssSelector("#navbar > div.hidden.lg" +
                    "\\:block > nav > div.main-menu__right > div > div > div"));

                Assert.IsTrue(true, "Pass");

            }
            // Không bắt được tài khoản ==> False
            catch (NoSuchElementException)
            {

                Assert.IsTrue(false, "Failed");
            }
            
        }

        [TestMethod]
        // Nhập đúng số điện thoại
        // Sai password
        // Tìm thấy thông báo: sai mật khẩu hoặc password
        public void Test_Login__Case2_AnBao()
        {
            // SDT: 0326929359
            // pass: Bao12345@
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            IWebElement login_AnBao = driver_AnBao.FindElement(By.CssSelector("#navbar > div.hidden.lg" +
                "\\:block > nav > div.main-menu__right > div > button:nth-child(1)"));
            login_AnBao.Click();

            // tìm ô số điện thoại ==> truyền vào số điện thoại
            IWebElement tel_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div.phone-input > div > input"));
            tel_AnBao.SendKeys("0326929359");

            // tìm ô password ==> truyền vào password
            IWebElement password_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div:nth-child(5) > div > input"));
            password_AnBao.SendKeys("Bao12345");
            Thread.Sleep(1000); // quan sát dữ liệu được điền

            // tìm button đăng nhập ==> Click
            IWebElement button_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5) > " +
                "div > div > form > button"));

            button_AnBao.Click();

            Thread.Sleep(1000); // chờ để bắt element bên dưới


            try
            {
                // Kỳ vọng bắt được thông báo: sai mật khẩu hoặc password => Pass
                IWebElement account_AnBao= driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5) > div > div > " +
                    "form > span.font-nunito.font-normal.italic.text-xs.leading-4.text-status-danger.mb-4"));

                Assert.IsTrue(true, "Pass");

            }
           
            catch (NoSuchElementException)
            {

                Assert.IsTrue(false, "Failed");
            }

        }

        [TestMethod]
        // Không nhập số điện thoại
        // Tìm thấy thông báo: vui lòng nhập số điện thoại hợp lệ
        public void Test_Login__Case3_AnBao()
        {
            // SDT: 0326929359
            // pass: Bao12345@
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            IWebElement login_AnBao = driver_AnBao.FindElement(By.CssSelector("#navbar > div.hidden.lg" +
                "\\:block > nav > div.main-menu__right > div > button:nth-child(1)"));
            login_AnBao.Click();

            // tìm ô số điện thoại ==> Không truyền giá trị
            IWebElement tel_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div.phone-input > div > input"));
            tel_AnBao.SendKeys("");

            // tìm ô password ==> truyền vào password
            IWebElement password_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5)" +
                " > div > div > form > div:nth-child(5) > div > input"));
            password_AnBao.SendKeys("Bao12345");
            Thread.Sleep(1000); // quan sát dữ liệu được điền

            // tìm button đăng nhập ==> Click
            IWebElement button_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5) > " +
                "div > div > form > button"));

            button_AnBao.Click();

            Thread.Sleep(1000); // chờ để bắt element bên dưới


            try
            {
                // Kỳ vọng bắt được thông báo: Vui lòng nhập số điện thoại hợp lệ => Pass
                IWebElement accont_AnBAo = driver_AnBao.FindElement(By.CssSelector("#__layout > div > header > div:nth-child(5) > div > div > form > " +
                    "div.phone-input > span"));

                Assert.IsTrue(true, "Pass");

            }

            catch (NoSuchElementException)
            {

                Assert.IsTrue(false, "Failed");
            }

        }
    }
}


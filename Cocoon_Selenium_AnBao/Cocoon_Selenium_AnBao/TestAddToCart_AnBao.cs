using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Cocoon_Selenium_AnBao
{
   
    [TestClass]
    public class TestAddToCart_AnBao
    {
        [TestMethod]
        // Case1: Sản phẩm còn hàng
        // Khi ấn vào button thêm sản phẩm ==> sản phẩm trong giỏ hảng sẽ tăng lên
        public void TC1_TestAddToCart_AnBao()
        {

            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/san-pham/giftbox-qua-buoi");

            // Bắt button của sản phẩm còn hàng ==> click 
            // Sản phẩm: Gift box quả bưởi
            IWebElement button_AnBao = driver_AnBao.FindElement(By.ClassName("add-to-cart"));
            // mô phỏng hành vi chuột thật, di chuyển con trỏ đến phần tử trước, rồi click
            // do button yêu cầu phải hover hoặc đã được phủ lớp nào trước đó
            Actions actions_AnBao = new Actions(driver_AnBao);

            actions_AnBao.MoveToElement(button_AnBao).Click().Perform();

            // bắt được thông báo giỏ hàng tăng thêm ==> Pass
            try
            {
                IWebElement notification_AnBao = driver_AnBao.FindElement(By.ClassName("shopping-cart__topbar"));
                Assert.IsTrue(true);
                Console.WriteLine("Pass");
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
                Console.WriteLine("False");
            }
        }

        [TestMethod]
        // Case2: Sản phẩm hết hàng
        // Khi ấn vào butoon thêm sản phẩm ==> sản phẩm trong giỏ không tăng lên
        public void TC2_TestAddToCart_AnBao()
        {

            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/danh-muc/combo-bo-san-pham");

            // Bắt button của sản phẩm còn hàng ==> click 
            // Sản phẩm: Gift box vali "Một tình yêu"
            IWebElement button_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > div:nth-child(2) > main > div:nth-child(2) " +
                "> div:nth-child(2) > div > div.relative.flex.flex-col.justify-center.h-full.overflow-hidden.flex-1.ml-2.lg\\" +
                ":ml-0 > div.slick-slider.slick-initialized > div > div > div:nth-child(2) >" +
                " div > div > div > div.product-card__info > div.ml-1\\.5.hidden.lg\\:block > button"));

            // mô phỏng hành vi chuột thật, di chuyển con trỏ đến phần tử trước, rồi click
            // do button yêu cầu phải hover hoặc đã được phủ lớp nào trước đó
            Actions actions_AnBao = new Actions(driver_AnBao);

            actions_AnBao.MoveToElement(button_AnBao).Click().Perform();

            // Không bắt được thông báo thêm sản phẩm thành công ==> pass
            try
            {
                IWebElement notification_AnBao = driver_AnBao.FindElement(By.ClassName("shopping-cart__topbar"));
                Assert.IsTrue(true);
                Console.WriteLine("Pass");
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
                Console.WriteLine("False");
            }


        }
    }
}

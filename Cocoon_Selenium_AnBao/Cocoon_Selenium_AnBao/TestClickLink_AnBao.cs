using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Threading;

namespace Cocoon_Selenium_AnBao
{

    [TestClass]
    public class TestClickLink_AnBao
    {
        [TestMethod]
        // Case3: Click link facebook
        // kỳ vọng: mở ra trang mới và bắt được tên miền chứa facebook
        public void TC3_TestClickLink_Facebook_AnBao()
        {
            //Tạo đối tượng IWebDriver
            IWebDriver driver_AnBao = new ChromeDriver();
            //Điều hướng tới website qua đường link
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            // Tìm thẻ chứa link facebook
            IWebElement link_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > footer > div > div.px-2.pt-3.pb-5.footer-content.lg" +
                "\\:py-6.lg\\:px-10.\\32 xl\\:px-16 > div.flex.flex-row.font-nunito.text-primary-dark.lg" +
                "\\:mb-6 > div.flex.flex-col.flex-1.ml-4 > a:nth-child(2)"));


            // mô phỏng hành vi chuột thật, di chuyển con trỏ đến phần tử trước, rồi click
            // do button yêu cầu phải hover hoặc đã được phủ lớp nào trước đó
            Actions actions_AnBao = new Actions(driver_AnBao);

            actions_AnBao.MoveToElement(link_AnBao).Click().Perform();

            // lưu list các tab vào biến tabs
            var tabs_AnBao = driver_AnBao.WindowHandles.ToList();

            // chuyển driver đến tab mới mở
            driver_AnBao.SwitchTo().Window(tabs_AnBao[1]);

            // nếu tên miền tab mới mở chứa: facebook ==> pass
            if (driver_AnBao.Url.Contains("facebook"))
            {
                Assert.IsTrue(true);
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine(driver_AnBao.Url);
                Assert.IsTrue(false);
                Console.WriteLine("Failed");
            }

        }

        [TestMethod]
        // Case4: Click link youtube
        // kỳ vọng: mở ra trang mới và tên miền có chứa youtube
        public void TC4_TestClickLink_Youtube_AnBao()
        {
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");

            // tìm thẻ chứa link youtube
            IWebElement link_AnBao = driver_AnBao.FindElement(By.CssSelector("#__layout > div > footer > div > div.px-2.pt-3.pb-5.footer-content.lg" +
                "\\:py-6.lg\\:px-10.\\32 xl\\:px-16 > div.flex.flex-row.font-nunito.text-primary-dark.lg" +
                "\\:mb-6 > div.flex.flex-col.flex-1.ml-4 > a:nth-child(4) > span.w-7"));


            // mô phỏng hành vi chuột thật, di chuyển con trỏ đến phần tử trước, rồi click
            // do button yêu cầu phải hover hoặc đã được phủ lớp nào trước đó
            Actions actions_AnBao = new Actions(driver_AnBao);

            actions_AnBao.MoveToElement(link_AnBao).Click().Perform();

            // lưu list các tab vào biến tabs
            var tabs_AnBao = driver_AnBao.WindowHandles.ToList();

            // chuyển driver đến tab mới mở
            driver_AnBao.SwitchTo().Window(tabs_AnBao[1]);

            // nếu tên miền tab mới mở chứa: youtube ==> pass
            if (driver_AnBao.Url.Contains("youtube"))
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

        // Case5: Click nút đổi ngôn ngữ (EN → VI)
        // Kỳ vọng: Sau khi click, nút "EN" đổi thành "VI"
        [TestMethod]
        public void TC5_TestSwitchLanguage_AnBao()
        {
            // Khởi tạo trình duyệt
            IWebDriver driver_AnBao = new ChromeDriver();
            driver_AnBao.Navigate().GoToUrl("https://cocoonvietnam.com/");
            // Chờ trang tải xong
            Thread.Sleep(3000); 

            try
            {
                // Tìm button bằng class 'nav-lang'
                IWebElement btnLanguage_AnBao = driver_AnBao.FindElement(By.ClassName("nav-lang"));
                string initialText_AnBao = btnLanguage_AnBao.Text.Trim().ToLower();

                // Kiểm tra nếu ban đầu là "en"
                if (initialText_AnBao == "en")
                {
                    Console.WriteLine("-> Nút ban đầu là 'EN', trang đang ở Tiếng Việt.");

                    // Click vào nút "EN"
                    btnLanguage_AnBao.Click();
                    // Chờ trang tải lại 3s
                    Thread.Sleep(3000); 

                    // Lấy lại text của button sau khi click
                    string newText_AnBao = driver_AnBao.FindElement(By.ClassName("nav-lang")).Text.Trim().ToLower();

                    if (newText_AnBao == "vi")
                    {
                        Console.WriteLine("-> Ngôn ngữ đã chuyển sang Tiếng Anh, nút đã đổi thành 'VI'.");
                        Assert.IsTrue(true);
                        Console.WriteLine("=> pass");
                    }
                    else
                    {
                        Console.WriteLine($"-> Nút không đổi thành 'VI', vẫn là '{newText_AnBao}'. Kiểm tra thất bại!");
                        Assert.Fail();
                        Console.WriteLine("=> fail!");
                    }
                }
                else
                {
                    Console.WriteLine($"-> Nút ban đầu không phải 'EN' mà là '{initialText_AnBao}'. Kiểm tra thất bại!");
                    Assert.Fail();
                    Console.WriteLine("=> fail!");
                }
            }
            catch (Exception e_AnBao)
            {
                Console.WriteLine(" Lỗi xảy ra: " + e_AnBao.Message);
                Assert.Fail();
                Console.WriteLine("=> fail!");
            }

        }
    }
}

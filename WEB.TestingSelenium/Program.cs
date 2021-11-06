using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;
using System.IO;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WEB.TestingSelenium
{
    class Program
    {
        [Test]
        public void TC1_Dung()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            String tendn = null;
            String matkhau = null;
            FileStream fs = new FileStream("E:/WEB/KĐCLPM/WebBanQuanAo/WEB.TestingSelenium/Data_DN.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Login");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                tendn = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                matkhau = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                ChromeDriver driver = new ChromeDriver();
                driver.Url = "http://localhost:31615/NguoiDung/DangNhap";
                driver.Navigate();
                driver.FindElementByName("TenDN").SendKeys(tendn);
                // IWebElement username = driver.FindElementById("TenDN");
                driver.FindElementByName("MatKhau").SendKeys(matkhau);
                // IWebElement password = driver.FindElementById("MatKhau");
                driver.FindElementById("login-btn").Click();
                String actualResult = "Trang Chủ";
                String expectedResult = driver.Title;
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [Test]
        public void TC1_Sai()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            String tendn = null;
            String matkhau = null;
            FileStream fs = new FileStream("E:/WEB/KĐCLPM/WebBanQuanAo/WEB.TestingSelenium/Data_sai.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Login");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                tendn = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                matkhau = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                ChromeDriver driver = new ChromeDriver();
                driver.Url = "http://localhost:31615/NguoiDung/DangNhap";
                driver.Navigate();
                driver.FindElementByName("TenDN").SendKeys(tendn);
                // IWebElement username = driver.FindElementById("TenDN");
                driver.FindElementByName("MatKhau").SendKeys(matkhau);
                // IWebElement password = driver.FindElementById("MatKhau");
                driver.FindElementById("login-btn").Click();
                String actualResult = "Login";
                String expectedResult = driver.Title;
                Assert.AreEqual(expectedResult, actualResult);
            }
            
        }

        [Test]
        public void TC2()
        {

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string soluong = null;

            FileStream fs = new FileStream("E:/WEB/KĐCLPM/WebBanQuanAo/WEB.TestingSelenium/Data_GioHang.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Soluong");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                soluong = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                ChromeDriver driver = new ChromeDriver();
                driver.Url = "http://localhost:31615/";
                driver.Navigate();
                driver.FindElementByXPath("//body/div[@class='product']/div[@class='product']/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/a[1]").Click();
                driver.FindElementById("them-btn").Click();
                driver.FindElementByXPath("//div[@class='total']").Click();
                driver.FindElementByLinkText("Cập Nhật").Click();
                driver.FindElementById("SoLuong").Clear();
                driver.FindElementById("SoLuong").SendKeys(soluong);
                driver.FindElementById("btnCapNhatGH").Click();
                String actualResult = driver.FindElementById("dg").Text;
                string getR = driver.FindElementById("tt").Text;
                string expectedResult =  Convert.ToString(int.Parse(soluong) * int.Parse(getR));
                
                Assert.AreEqual(expectedResult, actualResult);
            }
         
        }
        [Test]
        public void TC3_AdminDung()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            String tendn = null;
            String matkhau = null;
            FileStream fs = new FileStream("E:/WEB/KĐCLPM/WebBanQuanAo/WEB.TestingSelenium/Data_DNAddung.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Login");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                tendn = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                matkhau = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                ChromeDriver driver = new ChromeDriver();
                driver.Url = "http://localhost:31615/Admin/Index";
                driver.Navigate();
                driver.FindElementByName("txtUser").SendKeys(tendn);
                // IWebElement username = driver.FindElementById("TenDN");
                driver.FindElementByName("txtPass").SendKeys(matkhau);
                // IWebElement password = driver.FindElementById("MatKhau");
                driver.FindElementById("btnDangNhap1").Click();
                String actualResult = "XemChiTiet";
                String expectedResult = driver.Title;
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
        [Test]
        public void TC3_AdminSai()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            String tendn = null;
            String matkhau = null;
            FileStream fs = new FileStream("E:/WEB/KĐCLPM/WebBanQuanAo/WEB.TestingSelenium/Data_DNAdsai.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Login");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                tendn = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                matkhau = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                ChromeDriver driver = new ChromeDriver();
                driver.Url = "http://localhost:31615/Admin/Index";
                driver.Navigate();
                driver.FindElementByName("txtUser").SendKeys(tendn);
                // IWebElement username = driver.FindElementById("TenDN");
                driver.FindElementByName("txtPass").SendKeys(matkhau);
                // IWebElement password = driver.FindElementById("MatKhau");
                driver.FindElementById("btnDangNhap1").Click();
                String actualResult = "http://localhost:31615/Admin/LoginAdmin";
                String expectedResult = driver.Url;
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
        static void Main(string[] args)
        {
           
        }
    }
}

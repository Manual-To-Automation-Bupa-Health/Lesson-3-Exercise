using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Lesson3_Exercise.Drivers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3_Exercise.PageObjects
{
    internal class ProductsObject
    {
        private readonly WebDriver _driver;
        private readonly DefaultWait<IWebDriver> _fluentWait;

        public IWebElement GetProductItemElement() { return _fluentWait.Until(x => x.FindElement(By.XPath("//a[@href='/products']"))); }
        public IWebElement GetViewProductElement(int prodNum) { return _fluentWait.Until(x => x.FindElement(By.XPath("//a[@href='/product_details/" + prodNum.ToString() + "']"))); }
        public IWebElement GetAddToCartButtonElement() { return _fluentWait.Until(x => x.FindElement(By.CssSelector(".cart"))); }
        public IWebElement GetViewCartElement() { return _fluentWait.Until(x => x.FindElement(By.XPath("//div[@id='cartModal']/div[1]/div[1]/div[2]/p[2]/a"))); }

        public ProductsObject(WebDriver driver)
        {
            _driver = driver;

            _fluentWait = new DefaultWait<IWebDriver>(_driver.Current);
            _fluentWait.Timeout = TimeSpan.FromSeconds(10);
            _fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        }

        public void GoToProductsPage()
        {
            this.GetProductItemElement().Click();
        }

        public void AddProductToCart(int productNum)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver.Current;
            js.ExecuteScript("window.scrollTo(100, 0)");
            this.GetViewProductElement(productNum).Click();
            this.GetAddToCartButtonElement().Click();
            this.GetViewCartElement().Click();
            
        }


    }
}

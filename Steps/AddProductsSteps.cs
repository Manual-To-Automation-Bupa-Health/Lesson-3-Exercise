using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Lesson3_Exercise.Drivers;
using Lesson3_Exercise.PageObjects;
using System;
 using TechTalk.SpecFlow;
 
 namespace Lesson3_Exercise.Steps
 {
     [Binding]
     public class AddProductSteps
     {
        private readonly WebDriver _webDriver;
        readonly DefaultWait<IWebDriver> fluentWait;
        readonly ProductsObject _productsObject;

        public AddProductSteps(WebDriver driver)
        {
            _webDriver = driver;

            fluentWait = new DefaultWait<IWebDriver>(_webDriver.Current);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);

            _productsObject = new ProductsObject(_webDriver);
        }

        [Given(@"I am currently on the homepage ""(.*)""")]
        public void GivenIAmCurrentlyOnTheHomepage(string url)
        {
            _webDriver.Current.Navigate().GoToUrl(url);
            _webDriver.Current.Manage().Window.Maximize();
        }
         
        [When(@"I click on the Products menu item")]
        public void WhenIClickOnTheProductsMenuItem()
        {
            _productsObject.GoToProductsPage();
        }
         
        [When(@"I add a product to the cart")]
        public void WhenIAddAProductToTheCart()
        {
            _productsObject.AddProductToCart(1);
        }

        [Then(@"I should see one product in my cart")]
        public void ThenIShouldSeeOneProductInMyCart()
        {
            fluentWait.Until(x => x.FindElements(By.XPath("//tbody/tr")).Count.Should().Be(1));
        }

        [When(@"I add another product to the cart")]
        public void WhenIAddAnotherProductToTheCart()
        {
            _productsObject.GoToProductsPage();
            _productsObject.AddProductToCart(2);
        }
         
        [Then(@"I should see two products in my cart\\")]
        public void ThenIShouldSeeTwoProductsInMyCart()
        {
            fluentWait.Until(x => x.FindElements(By.XPath("//tbody/tr")).Count.Should().Be(2));
        }
     }
 }
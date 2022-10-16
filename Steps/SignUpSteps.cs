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
     public class SignUpSteps
     {
        private readonly WebDriver _webDriver;
        private readonly SignUpObject _signUpObject;

        private string firstName = "FirstName";
        private string lastName = "LastName";
        private string emailAddress = "test" + GetRandomNumber() + "@testemail" + GetRandomNumber() + ".com";
        readonly DefaultWait<IWebDriver> fluentWait;

        public SignUpSteps(WebDriver driver)
        {
            _webDriver = driver;

            _signUpObject = new SignUpObject(_webDriver);

            fluentWait = new DefaultWait<IWebDriver>(_webDriver.Current);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            

        }
        private static int GetRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 99999);
        }

        [Given(@"I go to ""(.*)""")]
         public void GivenIGoTo(string url)
         {
            _webDriver.Current.Navigate().GoToUrl(url);
         }
         
         [When(@"I click on Sign Up / Login")]
         public void WhenIClickOnSignUpLogin()
         {
            _signUpObject.ClickSignUpButton();
         }
         
         [When(@"I enter a name and email address into the sign up section")]
         public void WhenIEnterANameAndEmailAddressIntoTheSignUpSection()
         {
            string fullName = firstName + " " + lastName;
            _signUpObject.SignUpForNewAccount(fullName, emailAddress);
         }
         
         [When(@"I fill in my personal details")]
         public void WhenIFillInMyPersonalDetails()
         {
            _signUpObject.EnterAccountDetails(firstName, lastName);
         }
         
         [Then(@"My new account was successfully created")]
         public void ThenMyNewAccountWasSuccessfullyCreated()
         {
            IWebElement continueButton = fluentWait.Until(x => x.FindElement(By.XPath("//a[@data-qa='continue-button']")));
            continueButton.Displayed.Should().BeTrue();

            continueButton.Click();

            IWebElement logoutElement = fluentWait.Until(x => x.FindElement(By.XPath("//a[@href='/logout']")));
            logoutElement.Displayed.Should().BeTrue();
         }
     }
 }
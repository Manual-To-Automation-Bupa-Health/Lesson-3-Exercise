using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Lesson3_Exercise.Drivers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3_Exercise.PageObjects
{
    public class SignUpObject
    {
        private readonly WebDriver _driver;
        private readonly DefaultWait<IWebDriver> _fluentWait;

        public IWebElement getSignUpElement() { return _driver.Current.FindElement(By.XPath("//a[@href='/login']")); }
        public IWebElement getNameField() { return _fluentWait.Until(x => x.FindElement(By.XPath("//input[@data-qa='signup-name']"))); }
        public IWebElement getEmailAddressField() { return _driver.Current.FindElement(By.XPath("//input[@data-qa='signup-email']")); }
        public IWebElement getSignUpButton() { return _driver.Current.FindElement(By.XPath("//button[@data-qa='signup-button']")); }

        public IWebElement getGenderSelectField() { return _fluentWait.Until(x => x.FindElement(By.Id("id_gender1"))); }
        public IWebElement getPasswordField() { return _driver.Current.FindElement(By.Id("password")); }
        public SelectElement getDaysDropdown() { return new SelectElement(_driver.Current.FindElement(By.Id("days"))); }
        public SelectElement getMonthsDropdown() { return new SelectElement(_driver.Current.FindElement(By.Id("months"))); }
        public SelectElement getYearsDropdown() { return new SelectElement(_driver.Current.FindElement(By.Id("years"))); }
        public IWebElement getFirstNameField() { return _driver.Current.FindElement(By.Id("first_name")); }
        public IWebElement getLastNameField() { return _driver.Current.FindElement(By.Id("last_name")); }
        public IWebElement getAddressLine1Field() { return _driver.Current.FindElement(By.Id("address1")); }
        public IWebElement getStateField() { return _driver.Current.FindElement(By.Id("state")); }
        public IWebElement getCityField() { return _driver.Current.FindElement(By.Id("city")); }
        public IWebElement getZipCodeField() { return _driver.Current.FindElement(By.Id("zipcode")); }
        public IWebElement getMobileNumberField() { return _driver.Current.FindElement(By.Id("mobile_number")); }
        public IWebElement getCreateAccountButton() { return _driver.Current.FindElement(By.XPath("//button[@data-qa='create-account']]")); }

        public IWebElement getContinueButton() { return _fluentWait.Until(x => x.FindElement(By.XPath("//a[@data-qa='continue-button']"))); }
        public IWebElement getLogoutElement() { return _fluentWait.Until(x => x.FindElement(By.XPath("//a[@href='/logout']"))); }

        public SignUpObject(WebDriver driver)
        {
            _driver = driver;
            _fluentWait = new DefaultWait<IWebDriver>(_driver.Current);
            _fluentWait.Timeout = TimeSpan.FromSeconds(5);
            _fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        }

        public void ClickSignUpButton()
        {
            getSignUpElement().Click();
        }

        public void SignUpForNewAccount(string name, string emailAddress)
        {
            getNameField().SendKeys(name);
            getEmailAddressField().SendKeys(emailAddress);
            getSignUpButton().Click();
        }

        public void EnterAccountDetails(string firstName, string lastName)
        {
            getGenderSelectField().Click();
            getPasswordField().SendKeys("P@ssword123!");
            getDaysDropdown().SelectByValue("1");
            getMonthsDropdown().SelectByValue("1");
            getYearsDropdown().SelectByValue("1990");
            getFirstNameField().SendKeys(firstName);
            getLastNameField().SendKeys(lastName);
            getAddressLine1Field().SendKeys("1 Main Street");
            getStateField().SendKeys("State");
            getCityField().SendKeys("City");
            getZipCodeField().SendKeys("12345");
            getMobileNumberField().SendKeys("1234567890");

            getCreateAccountButton().Click();
        }
    }
}

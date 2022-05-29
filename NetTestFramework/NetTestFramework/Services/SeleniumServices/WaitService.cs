using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NetTestFramework.Services;

public class WaitService
{
    private IWebDriver _driver;
    private static WebDriverWait _wait;
    private readonly DefaultWait<IWebDriver> _fluentWait;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout));
        
        _fluentWait = new DefaultWait<IWebDriver>(_driver)
        {
            Timeout = TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout),
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public IWebElement WaitElementIsVisible(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }
    
    public static IWebElement WaitElementIsExist(By locator)
    {
        return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }

    public IWebElement WaitQuickElement(By locator)
    {
        return _fluentWait.Until(x => x.FindElement(locator));
    }
}
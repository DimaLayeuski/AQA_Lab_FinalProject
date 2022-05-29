using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; }
    protected WaitService WaitService { get; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);
    }

    protected abstract By GetPageIdentifier();
    public bool PageOpened => WaitService.WaitElementIsExist(GetPageIdentifier()).Displayed;
}
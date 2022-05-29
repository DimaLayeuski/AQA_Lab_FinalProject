using NetTestFramework.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NetTestFramework.Tests;

public class BaseTest
{
    protected IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new BrowserService().Driver;
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
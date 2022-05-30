using System.Threading;
using NetTestFramework.Pages;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Steps;

public class CreateRepositoryStep
{
    private IWebDriver _driver;
    protected MainPage _mainPage;
    private CreateNewRepositoryPage _createNewRepositoryPage;

    public CreateRepositoryStep(IWebDriver driver)
    {
        _driver = driver;
        _mainPage = new MainPage(_driver);
        _createNewRepositoryPage = new CreateNewRepositoryPage(_driver);
    }

    public RepositoryPage CreateRepository(string name)
    {
        _mainPage.CreateRepositoryButton.Click();
        _createNewRepositoryPage.RepositoryName.SendKeys(name);
        Thread.Sleep(500);
        _createNewRepositoryPage.CreateRepository.Click();
        return new RepositoryPage(_driver);
    }
}
using NetTestFramework.Pages;
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
        _createNewRepositoryPage.CreateRepository.Click();
        return new RepositoryPage(_driver);
    }
}
using System.Threading;
using NetTestFramework.Pages;
using OpenQA.Selenium;

namespace NetTestFramework.Steps;

public class LoginStep
{
    private IWebDriver _driver;
    protected HomePage _homePage;
    protected LoginPage _loginPage;
    
    
    public LoginStep(IWebDriver driver)
    {
        _driver = driver;
        _homePage = new HomePage(_driver);
        _loginPage = new LoginPage(_driver);
    }
    
    public MainPage LoginWithUsernameAndPassword(string username, string password)
    {
        _homePage.OpenPage();
        _homePage.SignIn.Click();
        _loginPage.UsernameInput.SendKeys(username);
        _loginPage.PasswordInput.SendKeys(password);
        _loginPage.LoginButton.Click();
        return new MainPage(_driver);
    }
    
    public FaildLoginPage LoginWithIncorrectUsernameAndPassword(string username, string password)
    {
        _homePage.OpenPage();
        _homePage.SignIn.Click();
        _loginPage.UsernameInput.SendKeys(username);
        _loginPage.PasswordInput.SendKeys(password);
        _loginPage.LoginButton.Click();
        return new FaildLoginPage(_driver);
    }
}
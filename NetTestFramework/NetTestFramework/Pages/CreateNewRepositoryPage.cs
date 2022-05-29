using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class CreateNewRepositoryPage : BasePage
{
    private const string URI = "/new";

    private static readonly By RepositoryNameBy =
        By.XPath("//*[@class='form-control js-repo-name js-repo-name-auto-check short']");
    private static readonly By CreateRepositoryBy = By.XPath("//*[@class='btn-primary btn']");

    public IWebElement RepositoryName => WaitService.WaitElementIsExist(RepositoryNameBy);
    public IWebElement CreateRepository => WaitService.WaitElementIsExist(CreateRepositoryBy);

    public CreateNewRepositoryPage(IWebDriver driver) : base(driver)
    {
    }
    
    protected override By GetPageIdentifier()
    {
        return CreateRepositoryBy;
    }
}
using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class MainPage : BasePage
{
    private const string URI = "/";
    private static readonly By CreateRepositoryButtonBy = By.XPath("(//*[@class='btn btn-sm btn-primary'])[1]");
    private static readonly By ChooseNewRepositoryButtonBy = By.XPath("(//*[@href='/DimaLayeuskiAQA/NewRepository'])[2]");

    private static readonly By ChooseRenameRepositoryButtonBy =
        By.XPath("(//*[@href='/DimaLayeuskiAQA/RenameRepository'])[2]");    
    
    private static readonly By ChooseFileRepositoryButtonBy =
        By.XPath("(//*[@href='/DimaLayeuskiAQA/RepositoryForFileTest'])[2]");

    public By CountOfLinkToRepositoriesBy = By.XPath("//div[@class='wb-break-word']");

    public IWebElement CreateRepositoryButton => WaitService.WaitElementIsExist(CreateRepositoryButtonBy);
    public IWebElement ChooseNewRepositoryButton => WaitService.WaitElementIsExist(ChooseNewRepositoryButtonBy);
    public IWebElement ChooseRenameRepositoryButton => WaitService.WaitElementIsExist(ChooseRenameRepositoryButtonBy);
    public IWebElement ChooseFileRepositoryButton => WaitService.WaitElementIsExist(ChooseFileRepositoryButtonBy);
    
    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return CreateRepositoryButtonBy;
    }
}
using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class MainPage : BasePage
{
    private const string URI = "/";
    private static readonly By CreateRepositoryButtonBy = By.XPath("(//*[@class='btn btn-sm btn-primary'])[1]");
    private static readonly By ChooseRepositoryButtonBy = By.XPath("(//*[@href='/DimaLayeuskiAQA/NewRepository'])[2]");

    private static readonly By ChooseRenameRepositoryButtonBy =
        By.XPath("(//*[@href='/DimaLayeuskiAQA/RenameRepository'])[2]");

    public By CountOfLinkToRepositoriesBy = By.XPath("//div[@class='wb-break-word']");

    public IWebElement CreateRepositoryButton => WaitService.WaitElementIsExist(CreateRepositoryButtonBy);
    public IWebElement ChooseRepositoryButton => WaitService.WaitElementIsExist(ChooseRepositoryButtonBy);
    public IWebElement ChooseRenameRepositoryButton => WaitService.WaitElementIsExist(ChooseRenameRepositoryButtonBy);
    
    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return CreateRepositoryButtonBy;
    }
}
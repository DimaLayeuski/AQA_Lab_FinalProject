using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class RepositoryPage : BasePage
{
    private const string URI = "/DimaLayeuskiAQA/NewRepository";
    private static readonly By CreateNewFileLinkBy = By.XPath("//*[contains(text(),'creating a new file')]");
    private static readonly By SettingBy = By.XPath("//*[@id='settings-tab']");
    public readonly By NewFileLinkBy = By.XPath("//*[@class='js-navigation-open Link--primary']");

    public IWebElement CreateNewFileLink => WaitService.WaitElementIsExist(CreateNewFileLinkBy);
    public IWebElement Setting => WaitService.WaitElementToBeClickable(SettingBy);
    public IWebElement NewFileLink => WaitService.WaitElementIsExist(NewFileLinkBy);

    public RepositoryPage(IWebDriver driver) : base(driver)
    {
    }
    
    protected override By GetPageIdentifier()
    {
        return SettingBy;
    }
}
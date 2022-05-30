using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class NewFilePage : BasePage
{
    private const string URI = "/DimaLayeuskiAQA/NewRepository/blob/main/NewFile";
    private static readonly By ChangeFileLinkBy = By.XPath("//*[@class='btn-octicon tooltipped tooltipped-nw']");

    private static readonly By DeleteFileLinkBy =
        By.XPath("//*[@class='btn-octicon btn-octicon-danger tooltipped tooltipped-nw']");
    private static readonly By AddedLineBy = By.XPath("//*[@id='LC2']");

    public IWebElement ChangeFileLink => WaitService.WaitElementIsExist(ChangeFileLinkBy);
    public IWebElement DeleteFileLink => WaitService.WaitElementIsExist(DeleteFileLinkBy);
    public IWebElement AddedLine => WaitService.WaitElementIsExist(AddedLineBy);

    public NewFilePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return ChangeFileLinkBy;
    }
}
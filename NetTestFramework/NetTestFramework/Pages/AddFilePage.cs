using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class AddFilePage : BasePage
{
    private const string URI = "/DimaLayeuskiAQA/NewRepository/new/main";
    private static readonly By FileNameBy = By.XPath("//div//*[@name='filename']");
    private static readonly By InputTextBy = By.XPath("//*[@class=' CodeMirror-line ']");
    private static readonly By CommitNewFileBy = By.XPath("//*[@id='commit-summary-input']");
    private static readonly By CommitNewFileButtonBy = By.XPath("//*[@id='submit-file']");

    public IWebElement FileName => WaitService.WaitElementIsExist(FileNameBy);
    public IWebElement InputText => WaitService.WaitElementIsExist(InputTextBy);
    public IWebElement CommitNewFile => WaitService.WaitElementIsExist(CommitNewFileBy);
    public IWebElement CommitNewFileButton => WaitService.WaitElementIsExist(CommitNewFileButtonBy);

    public AddFilePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return FileNameBy;
    }
}
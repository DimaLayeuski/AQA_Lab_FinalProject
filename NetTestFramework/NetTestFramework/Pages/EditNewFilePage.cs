using System;
using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class EditNewFilePage : BasePage
{
    private const string URI = "/DimaLayeuskiAQA/NewRepository/edit/main/NewFile";
    private static readonly By FileNameBy = By.XPath("//div//*[@name='filename']");
    private static readonly By InputNewTextBy = By.XPath("(//*[@class=' CodeMirror-line '])[2]");
    private static readonly By CommitNewFileBy = By.XPath("//*[@id='commit-summary-input']");
    private static readonly By CommitNewFileButtonBy = By.XPath("//*[@id='submit-file']");

    public IWebElement FileName => WaitService.WaitElementIsExist(FileNameBy);
    public IWebElement InputNewText => WaitService.WaitElementIsExist(InputNewTextBy);
    public IWebElement CommitNewFile => WaitService.WaitElementIsExist(CommitNewFileBy);
    public IWebElement CommitNewFileButton => WaitService.WaitElementIsExist(CommitNewFileButtonBy);

    public EditNewFilePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return FileNameBy;
    }
}
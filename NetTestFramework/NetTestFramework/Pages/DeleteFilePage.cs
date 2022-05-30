using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class DeleteFilePage : BasePage
{
    private const string URI = "/DimaLayeuskiAQA/RepositoryForFileTest/delete/main/NewFile";
    private static readonly By CommitDeleteFileBy = By.XPath("//*[@id='commit-summary-input']");
    private static readonly By CommitDeleteFileButtonBy = By.XPath("//*[@id='submit-file']");

    public IWebElement CommitDeleteFile => WaitService.WaitElementIsExist(CommitDeleteFileBy);
    public IWebElement CommitDeleteFileButton => WaitService.WaitElementIsExist(CommitDeleteFileButtonBy);
    
    public DeleteFilePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return CommitDeleteFileButtonBy;
    }
}
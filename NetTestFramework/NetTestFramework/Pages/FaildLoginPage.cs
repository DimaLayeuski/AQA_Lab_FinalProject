using NetTestFramework.Services;
using OpenQA.Selenium;

namespace NetTestFramework.Pages;

public class FaildLoginPage : BasePage
{
    private const string URI = "/session";
    private static readonly By ErrorMessageBy = By.XPath("//div//*[@class='flash flash-full flash-error ']");

    public IWebElement ErrorMessage => WaitService.WaitElementIsExist(ErrorMessageBy);

    public FaildLoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return ErrorMessageBy;
    }
}
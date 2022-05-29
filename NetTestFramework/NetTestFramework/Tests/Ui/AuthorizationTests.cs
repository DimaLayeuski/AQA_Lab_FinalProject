using Allure.Commons;
using FluentAssertions;
using NetTestFramework.Pages;
using NetTestFramework.Services;
using NetTestFramework.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace NetTestFramework.Tests.Ui;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureEpic("Authorization-UI")]
[AllureSeverity(SeverityLevel.blocker)]
[Category("Authorization-UI")]
public class AuthorizationTests : BaseTest
{
    private HomePage _homePage = null!;
    private LoginPage _loginPage = null!;
    private MainPage _mainPage = null!;
    private FaildLoginPage _faildLoginPage = null!;


    [SetUp]
    public void InstantiateRequiredPages()
    {
        _homePage = new HomePage(_driver);
        _loginPage = new LoginPage(_driver);
        _mainPage = new MainPage(_driver);
        _faildLoginPage = new FaildLoginPage(_driver);
    }

    [Test]
    [Category("Positive")]
    [AllureSuite("Authorization-UI")]
    [AllureStep("Authorize using correct data")]
    public void Authorization_WithCorrectData_MainPageOpened()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.PageOpened.Should().BeTrue();
    }

    [Test]
    [Category("Negative")]
    [AllureSuite("Authorization-UI")]
    [AllureStep("Authorize using incorrect data")]
    [TestCase("DimaLayeuskiAQA","11111")]
    [TestCase("", "")]
    public void Authorization_WithIncorrectData_FaildLoginPageOpened(string username, string password)
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithIncorrectUsernameAndPassword(username, password);
        _faildLoginPage.PageOpened.Should().BeTrue();
    }
}
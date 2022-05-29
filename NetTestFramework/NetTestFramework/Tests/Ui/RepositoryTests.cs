using System.Threading;
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
[AllureEpic("Repository-UI")]
[AllureSeverity(SeverityLevel.blocker)]
[Category("Repository-UI")]
public class RepositoryTests : BaseTest
{
    private HomePage _homePage = null!;
    private LoginPage _loginPage = null!;
    private MainPage _mainPage = null!;
    private FaildLoginPage _faildLoginPage = null!;
    private CreateNewRepositoryPage _createNewRepositoryPage = null!;
    private RepositoryPage _repositoryPage = null!;
    private SettingPage _settingPage = null!;


    [SetUp]
    public void InstantiateRequiredPages()
    {
        _homePage = new HomePage(_driver);
        _loginPage = new LoginPage(_driver);
        _mainPage = new MainPage(_driver);
        _faildLoginPage = new FaildLoginPage(_driver);
        _createNewRepositoryPage = new CreateNewRepositoryPage(_driver);
        _repositoryPage = new RepositoryPage(_driver);
        _settingPage = new SettingPage(_driver);
    }

    [Test]
    [Order(1)]
    [Category("Positive")]
    [AllureSuite("Repository-UI")]
    [AllureStep("Create repository with correct name")]
    public void CreateRepository_RepositoryIsCreated()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.CreateRepositoryButton.Click();
        _createNewRepositoryPage.RepositoryName.SendKeys("NewRepository");
        Thread.Sleep(500);
        _createNewRepositoryPage.CreateRepository.Click();
        _repositoryPage.PageOpened.Should().BeTrue();
    }
    
    [Test]
    [Order(2)]
    [Category("Positive")]
    [AllureSuite("Repository-UI")]
    [AllureStep("Rename repository")]
    public void RenameRepository_RepositoryIsRenamed()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.ChooseRepositoryButton.Click();
        _repositoryPage.Setting.Click();
        _settingPage.RepositoryName.Clear();
        _settingPage.RepositoryName.SendKeys("RenameRepository");
        Thread.Sleep(500);
        _settingPage.RenameButton.Click();
        _repositoryPage.PageOpened.Should().BeTrue();
    }
    
    [Test]
    [Order(3)]
    [Category("Positive")]
    [AllureSuite("Repository-UI")]
    [AllureStep("Delete repository")]
    public void DeleteRepository_RepositoryIsDeleted() 
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.ChooseRenameRepositoryButton.Click();
        _repositoryPage.Setting.Click();
        _settingPage.DeleteRepositoryButton.Click();
        _settingPage.ConfirmInputBlock.SendKeys("DimaLayeuskiAQA/RenameRepository");
        _settingPage.ConfirmToDeleteButton.Click();
        _mainPage.PageOpened.Should().BeTrue();
        Assert.AreEqual(_driver.FindElements(_mainPage.CountOfLinkToRepositoriesBy).Count,2);
    }
}
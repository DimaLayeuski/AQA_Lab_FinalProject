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
[AllureEpic("Workspace-UI")]
[AllureSeverity(SeverityLevel.blocker)]
[Category("Workspace-UI")]
public class FileTests : BaseTest
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
    [AllureSuite("Workspace-UI")]
    [AllureStep("Create new file with correct name")]
    public void CreateFile_FileIsCreated()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        CreateRepositoryStep _createRepositoryStep = new CreateRepositoryStep(_driver);
        _createRepositoryStep.CreateRepository("RepositoryForFileTest");

        RepositoryPage _repositoryPage = new RepositoryPage(_driver);
        _repositoryPage.CreateNewFileLink.Click();

        AddFilePage _addFilePage = new AddFilePage(_driver);
        _addFilePage.FileName.SendKeys("NewFile");
        _addFilePage.InputText.SendKeys("Text in new file");
        _addFilePage.CommitNewFile.SendKeys("Commit text");
        _addFilePage.CommitNewFileButton.Click();
        Assert.AreEqual(_driver.FindElements(_repositoryPage.NewFileLinkBy).Count, 1);
    }
    
    [Test]
    [Order(2)]
    [Category("Positive")]
    [AllureSuite("Workspace-UI")]
    [AllureStep("Change file")]
    public void ChangeFile_FileIsChanged()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.ChooseFileRepositoryButton.Click();
        RepositoryPage _repositoryPage = new RepositoryPage(_driver);
        _repositoryPage.NewFileLink.Click();
        NewFilePage _newFilePage = new NewFilePage(_driver);
        _newFilePage.ChangeFileLink.Click();
        EditNewFilePage _editNewFilePage = new EditNewFilePage(_driver);
        _editNewFilePage.InputNewText.SendKeys("New text in file");
        _editNewFilePage.CommitNewFile.SendKeys("Commit new text");
        _editNewFilePage.CommitNewFileButton.Click();
        
        _newFilePage.AddedLine.Displayed.Should().BeTrue();
    }
    
    [Test]
    [Order(3)]
    [Category("Positive")]
    [AllureSuite("Workspace-UI")]
    [AllureStep("Delete file")]
    public void DeleteFile_FileIsDeleted()
    {
        LoginStep _loginStep = new LoginStep(_driver);
        _loginStep.LoginWithUsernameAndPassword(Configurator.Admin.Username, Configurator.Admin.Password);
        _mainPage.ChooseFileRepositoryButton.Click();

        RepositoryPage repositoryPage = new RepositoryPage(_driver);
        repositoryPage.NewFileLink.Click();
        NewFilePage _newFilePage = new NewFilePage(_driver);
        _newFilePage.DeleteFileLink.Click();
        DeleteFilePage _deleteFilePage = new DeleteFilePage(_driver);
        _deleteFilePage.CommitDeleteFile.SendKeys("Delete file");
        _deleteFilePage.CommitDeleteFileButton.Click();
        Assert.AreEqual(_driver.FindElements(_repositoryPage.NewFileLinkBy).Count,0);
        
        _repositoryPage.Setting.Click();
        _settingPage.DeleteRepositoryButton.Click();
        _settingPage.ConfirmInputBlock.SendKeys("DimaLayeuskiAQA/RepositoryForFileTest");
        _settingPage.ConfirmToDeleteButton.Click();
    }
}
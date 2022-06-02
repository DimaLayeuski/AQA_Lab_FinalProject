using System.Net;
using Allure.Commons;
using FluentAssertions;
using NetTestFramework.Clients;
using NetTestFramework.Faker;
using NetTestFramework.Models;
using NetTestFramework.Services;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Logger = NLog.Logger;

namespace NetTestFramework.Tests.Api;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureSeverity(SeverityLevel.blocker)]
public class CreateNewRepositoryTestApi : BaseTestApi
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project = null!;

    [Test]
    [Category("Positive")]
    [AllureName("Create a new repository with correct lenght of name")]
    [AllureTms("TMS", "&suite=2&case=12")]
    [TestCase(1)]
    [TestCase(100)]
    public void CreateNewRepository_NewRepositoryIsCreated(int lenghtOfRepositoryName)
    {
        _project = new ProjectFaker(lenghtOfRepositoryName).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
        _logger.Info(_project.ToString());
        RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [OneTimeTearDown]
    public void DeleteCreatedProject()
    {
        ProjectService?.DeleteRepository(Configurator.Admin.Username, _project.Name);
    }
}
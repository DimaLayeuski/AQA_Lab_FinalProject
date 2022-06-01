using System.Net;
using Allure.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using NetTestFramework.Clients;
using NetTestFramework.Faker;
using NetTestFramework.Models;
using NetTestFramework.Services;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace NetTestFramework.Tests.Api;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureSeverity(SeverityLevel.blocker)]
public class GetRepositoryTestApi : BaseTestApi
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger(); 
    private Project _project = null!;

    [OneTimeSetUp]
    public void CreateRandomProject()
    {
        _project = new ProjectFaker(5).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
    }
    
    [Test]
    [Category("Positive")]
    [AllureName("Get repository by name")]
    [AllureTms("TMS", "&suite=2&case=16")]
    [Order(1)]
    public void GetRepositoryTest()
    {
        var actualProject = ProjectService.GetRepository(Configurator.Admin.Username,_project.Name);
        _project = actualProject.Result;
        _logger.Info(_project.ToString());
        using (new AssertionScope())
        {
            RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actualProject.Result.Name.Should().Be(_project.Name);
        }
    }
    
    [OneTimeTearDown]
    public void DeleteCreatedProject()
    {
        ProjectService.DeleteRepository(Configurator.Admin.Username,_project.Name);
    }
}
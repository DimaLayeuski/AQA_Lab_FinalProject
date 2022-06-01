using System.Net;
using Allure.Commons;
using FluentAssertions;
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
public class DeleteRepositoryTestApi : BaseTestApi
{
    private Project _project = null!;
    
    [OneTimeSetUp]
    public void CreateRandomProject()
    {
        _project = new ProjectFaker(10).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
    }
    
    [Test]
    [Category("Negative")]
    [AllureName("Delete repository with incorrect name")]
    [AllureTms("TMS", "&suite=2&case=15")]
    [Order(1)]
    public void DeleteRepository_RepositoryIsNotFound()
    {
        var incorrectName = _project.Name + "2";
        var deleteStatus = ProjectService.DeleteRepository(Configurator.Admin.Username,incorrectName);
        deleteStatus.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    [Category("Positive")]
    [AllureName("Delete repository by name")]
    [AllureTms("TMS", "&suite=2&case=14")]
    [Order(2)]
    public void DeleteRepository_RepositoryIsDeleted()
    {
        var deleteStatus = ProjectService.DeleteRepository(Configurator.Admin.Username,_project.Name);
        deleteStatus.Should().Be(HttpStatusCode.NoContent);
    }
}
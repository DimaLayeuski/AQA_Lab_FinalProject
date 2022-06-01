using System.Net;
using FluentAssertions;
using NetTestFramework.Faker;
using NetTestFramework.Models;
using NetTestFramework.Services;
using NUnit.Framework;

namespace NetTestFramework.Tests.Api;

public class DeleteRepositoryTestApi : BaseTestApi
{
    private Project _project = null!;
    
    [OneTimeSetUp]
    public void CreateRandomProject()
    {
        _project = new ProjectFaker(5).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
    }

    [Test]
    [Order(1)]
    public void DeleteRepository_RepositoryIsDeleted()
    {
        var deleteStatus = ProjectService.DeleteRepository(Configurator.Admin.Username,_project.Name);
        deleteStatus.Should().Be(HttpStatusCode.NoContent);
    }
}
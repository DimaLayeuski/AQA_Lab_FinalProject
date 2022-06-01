using System.Net;
using FluentAssertions;
using NetTestFramework.Clients;
using NetTestFramework.Faker;
using NetTestFramework.Models;
using NetTestFramework.Services;
using NLog;
using NUnit.Framework;
using Logger = NLog.Logger;

namespace NetTestFramework.Tests.Api;

public class CreateNewRepositoryTestApi : BaseTestApi
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project = null!;

    [Test]
    [Order(1)]
    [TestCase(10)]
    public void CreateNewRepository_NewRepositoryIsCreated(int lenghtOfRepositoryName)
    {
        _project = new ProjectFaker(lenghtOfRepositoryName).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
        _logger.Info(_project.ToString());
        RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Test]
    [Order(2)]
    [TestCase(0)]
    public void AddRepositoryFailTest(int lenghtOfRepositoryName)
    {
        _project = new ProjectFaker(lenghtOfRepositoryName).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
        _logger.Info(_project.ToString());
        RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }
    
    [OneTimeTearDown]
    public void DeleteCreatedProject()
    {
        if (_project.Id != 0)
        {
            ProjectService.DeleteRepository(Configurator.Admin.Username, _project.Name);
        }
    }
}
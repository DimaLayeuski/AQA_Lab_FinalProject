using System.Net;
using Allure.Commons;
using FluentAssertions;
using NetTestFramework.Clients;
using NetTestFramework.Faker;
using NetTestFramework.Models;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Logger = NLog.Logger;

namespace NetTestFramework.Tests.Api;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureSeverity(SeverityLevel.blocker)]
public class CreateNewRepositoryFailTestApi : BaseTestApi
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project = null!;

    [Test]
    [Category("Negative")]
    [AllureName("Create a new repository with incorrect lenght of name")]
    [AllureTms("TMS", "&suite=2&case=13")]
    [TestCase(0)]
    public void AddRepositoryFailTest(int lenghtOfRepositoryName)
    {
        _project = new ProjectFaker(lenghtOfRepositoryName).Generate();
        var actualProject = ProjectService.AddRepository(_project);
        _project = actualProject.Result;
        _logger.Info(_project.ToString());
        RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }
}
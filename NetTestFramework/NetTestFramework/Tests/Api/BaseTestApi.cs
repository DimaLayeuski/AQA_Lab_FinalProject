using NetTestFramework.Clients;
using NetTestFramework.Services.ApiServices;
using NUnit.Framework;

namespace NetTestFramework.Tests.Api;

public class BaseTestApi
{
    protected ProjectService? ProjectService;

    [OneTimeSetUp]
    public void OneTimeSetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
    }
}
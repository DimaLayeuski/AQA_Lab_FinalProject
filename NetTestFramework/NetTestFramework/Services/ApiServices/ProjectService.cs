using System;
using System.Net;
using System.Threading.Tasks;
using NetTestFramework.Clients;
using NetTestFramework.Models;

namespace NetTestFramework.Services.ApiServices;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> GetProject(int projectId)
    {
        throw new NotImplementedException();
    }

    public Task<Project> AddProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<Project> UpdateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode DeleteProject(string projectId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
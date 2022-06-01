using System;
using System.Net;
using System.Threading.Tasks;
using NetTestFramework.Clients;
using NetTestFramework.Models;
using RestSharp;

namespace NetTestFramework.Services.ApiServices;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> AddRepository(Project project)
    {
        var request = new RestRequest("https://api.github.com/user/repos", Method.Post)
            .AddJsonBody(project);
        
        return _client.ExecuteAsync<Project>(request);
    }    
    
    public Task<Project> GetRepository(string owner, string repo)
    {
        var request = new RestRequest("https://api.github.com/repos/{owner}/{repo}", Method.Get)
            .AddUrlSegment("owner",owner)
            .AddUrlSegment("repo",repo);
            
        return _client.ExecuteAsync<Project>(request);
    }

    public HttpStatusCode DeleteRepository(string owner, string repo)
    {
        var request = new RestRequest("https://api.github.com/repos/{owner}/{repo}", Method.Delete)
            .AddUrlSegment("owner", owner)
            .AddUrlSegment("repo", repo);
            
        return _client.ExecuteAsync(request).Result.StatusCode;
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
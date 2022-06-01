using System.Net;
using System.Threading.Tasks;
using NetTestFramework.Models;

namespace NetTestFramework.Services.ApiServices;

public interface IProjectService
{
    Task<Project> AddRepository(Project project);
    Task<Project> GetRepository(string owner, string repo);
    HttpStatusCode DeleteRepository(string owner, string repo);
}
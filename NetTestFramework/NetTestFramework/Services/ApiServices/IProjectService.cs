using System.Net;
using System.Threading.Tasks;
using NetTestFramework.Models;

namespace NetTestFramework.Services.ApiServices;

public interface IProjectService
{
    Task<Project> GetProject(int projectId);
    Task<Project> AddProject(Project project);
    Task<Project> UpdateProject(Project project);
    HttpStatusCode DeleteProject(string projectId);
}
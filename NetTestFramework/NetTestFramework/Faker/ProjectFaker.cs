using NetTestFramework.Models;
using Bogus;

namespace NetTestFramework.Faker;

public sealed class ProjectFaker : Faker<Project>
{
    public ProjectFaker(int lenghtOfRepositoryName)
    {
        RuleFor(n => n.Name, f => f.Random.String2(lenghtOfRepositoryName));
        RuleFor(d => d.Description, f => f.Company.CatchPhrase());
        RuleFor(h => h.Homepage, f => "https://github.com");
        RuleFor(p => p.Private, f => f.Random.Bool());
        RuleFor(i => i.HasIssues, f => f.Random.Bool());
        RuleFor(p => p.HasProjects, f => f.Random.Bool());
        RuleFor(w => w.HasWiki, f => f.Random.Bool());
    }
}
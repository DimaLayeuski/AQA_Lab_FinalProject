using NetTestFramework.Models;
using Bogus;

namespace NetTestFramework.Faker;

public sealed class ProjectFaker : Faker<Project>
{
    public ProjectFaker(int nameLenght = 10)
    {
        RuleFor(b => b.Name, f => f.Random.String2(nameLenght));
        RuleFor(b => b.Description, f => f.Company.CatchPhrase());
    }
}
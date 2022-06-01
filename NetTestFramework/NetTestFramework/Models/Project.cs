using System.Text.Json.Serialization;

namespace NetTestFramework.Models;

public record Project
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("node_id")] public string? NodeId { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("homepage")] public string? Homepage { get; set; }
    [JsonPropertyName("private")] public bool Private { get; set; }
    [JsonPropertyName("has_issues")] public bool HasIssues { get; set; }
    [JsonPropertyName("has_projects")] public bool HasProjects { get; set; }
    [JsonPropertyName("has_wiki")] public bool HasWiki { get; set; }
}
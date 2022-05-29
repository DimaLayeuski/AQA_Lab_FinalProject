using System.Text.Json.Serialization;

namespace NetTestFramework.Models;

public record Project
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("node_id")] public string? NodeId { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("description")] public string? Description { get; init; }
    [JsonPropertyName("full_name")] public string? FullName { get; init; }
}
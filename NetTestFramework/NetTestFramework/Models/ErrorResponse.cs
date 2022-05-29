using System.Text.Json.Serialization;

namespace NetTestFramework.Models;

public class ErrorResponse
{
    [JsonPropertyName("name")] public string[]? Name { get; set; }
}
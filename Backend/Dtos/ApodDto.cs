using System.Text.Json.Serialization;

namespace NASA_APOD;

public record class ApodDto(
    [property: JsonPropertyName("date")]
    DateOnly Date,
    [property: JsonPropertyName("explanation")]
    string Explanation,
    [property: JsonPropertyName("hdurl")]
    string Hdurl,
    [property: JsonPropertyName("media_type")]
    string MediaType,
    // [property: JsonPropertyName("service_version")]
    // string ServiceVersion,
    [property: JsonPropertyName("title")]
    string Title,
    [property: JsonPropertyName("url")]
    string Url,
    int Id
);

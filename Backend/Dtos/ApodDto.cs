using System.Text.Json.Serialization;

namespace NASA_APOD;

public record class ApodDto(
    DateOnly Date,
    string Explanation,
    string Hdurl,
    [property: JsonPropertyName("media_type")]
    string MediaType,
    [property: JsonPropertyName("service_version")]
    string ServiceVersion,
    string Title,
    string Url,
    int Id
);

namespace NASA_APOD;

public record class ApodDto(
    DateOnly Date,
    string Explanation,
    string Hdurl,
    string MediaType,
    string ServiceVersion,
    string Title,
    string Url,
    int Id
);

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace NASA_APOD;

public static class ApodEndpoints
{
    public static void MapApodEndpoints(this WebApplication app)
    {
        // GET 
        app.MapGet("/apod/", async (ApodContext dbContext) =>
        {
            return await dbContext.Apods.ToListAsync();
        });

        // GET /id (unique id given to each "Date" the user saves)
        app.MapGet("/apod/saved/id/{id}", async (int id, ApodContext dbContext) =>
        {
            var apotd = await dbContext.Apods.FindAsync(id);
            return apotd is null ? Results.NotFound() : Results.Ok(apotd);
        });

        // GET /date (retrives info directly from NASA API)
        app.MapGet("/apod/date/{date}", async (string date, [FromServices] HttpClient httpClient, IConfiguration config) =>
        {
            string apiKey = config["NasaApiKey"]!;
            string json = await httpClient.GetStringAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}&date={date}");
            return Results.Ok(JsonSerializer.Deserialize<Apod>(json));
        });

        // POST /id (save to favorites?)
        app.MapPost("/apod/", async (ApodDto newApod, ApodContext dbContext) =>
        {
            Apod apod = new()
            {
                Date = newApod.Date,
                Explanation = newApod.Explanation,
                Hdurl = newApod.Hdurl,
                MediaType = newApod.MediaType,
                ServiceVersion = newApod.ServiceVersion,
                Title = newApod.Title,
                Url = newApod.Url,
            };
            dbContext.Add(apod);
            await dbContext.SaveChangesAsync();
            return Results.Ok(apod);
        });

        // PUT (probably not needed for this program so far at least)
        // app.MapPut("/apod/saved/id/{id}", (int id, ApodContext dbContext) =>
        // {
            
        // });
        
        app.MapDelete("/apod/saved/id/{id}", async (int id, ApodContext dbContext) =>
        {
            await dbContext.Apods.Where(apod => apod.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
    }
}

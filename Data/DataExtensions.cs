using Microsoft.EntityFrameworkCore;

namespace NASA_APOD;

public static class DataExtensions
{
    public static void migrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApodContext>();
        dbContext.Database.Migrate();
    }

    public static void AddApodDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("Apod");
        builder.Services.AddSqlite<ApodContext>(connString);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace NASA_APOD;

public class ApodContext(DbContextOptions<ApodContext> options) : DbContext(options)
{
    public DbSet<Apod> Apods => Set<Apod>();
}
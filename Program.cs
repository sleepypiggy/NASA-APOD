using NASA_APOD;
using NASA_APOD.Frontend.Components;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "Frontend/wwwroot"
});

builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("http://localhost:5256");
});

var connString = "Data Source=Apod.db";
builder.AddApodDb();
builder.Services.AddSqlite<ApodContext>(connString);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();
app.migrateDb();

app.MapApodEndpoints();

app.UseAntiforgery();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

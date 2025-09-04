using FilmDb.Adapter.Out.Persistence;
using FilmDb.Application;
using FilmDb.Application.Port.In;
using FilmDb.Application.Port.Out;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register FilmDb dependencies
builder.Services.AddSingleton<StaticFilmRepository>();
builder.Services.AddSingleton<ILoadAllFilmsPort, FilmPersistenceAdapter>();
builder.Services.AddSingleton<ILoadFilmPort, FilmPersistenceAdapter>();
builder.Services.AddSingleton<ISaveFilmPort, FilmPersistenceAdapter>();
builder.Services.AddSingleton<IGetFilmUseCase, FilmService>();
builder.Services.AddSingleton<ISaveFilmUseCase, FilmService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/health", () => "running");

app.Run();

namespace AppHost
{
    public partial class Program { }
}

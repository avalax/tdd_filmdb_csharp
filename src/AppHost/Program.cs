using FilmDb;
using Gui;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFilmDb();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var guiPath = Path.GetFullPath("../Gui");
    app.UseGuiDefaultFiles(guiPath);
    app.UseGuiStaticFiles(guiPath);
    app.UseGuiTypeScriptFiles(guiPath);
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.MapGet("/health", () => "running");
app.MapFallbackToFile("index.html");
app.Run();

namespace AppHost
{
    public class Program;
}
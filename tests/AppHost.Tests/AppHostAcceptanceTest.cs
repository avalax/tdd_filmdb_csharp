using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using System.Text;
using Xunit;

namespace AppHost.Tests;

using FilmDb.Domain;

public class AppHostAcceptanceTest(WebApplicationFactory<Program> factory) 
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Should_be_healthy()
    {
        var response = await _client.GetAsync("/health");
        var content = await response.Content.ReadAsStringAsync();
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("running", content);
    }
    
    [Fact]
    public async Task Should_access_swagger_ui()
    {
        var response = await _client.GetAsync("/swagger/index.html");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Swagger UI", content);
    }

    [Fact]
    public async Task Should_show_all_films_from_repository()
    {
        var response = await _client.GetAsync("/api/film");
        var content = await response.Content.ReadAsStringAsync();
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotEmpty(content);
        
        var films = JsonSerializer.Deserialize<Film[]>(content, new JsonSerializerOptions 
        { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        });
        
        Assert.NotNull(films);
        Assert.Equal(3, films.Length);
        Assert.Contains(films, f => f.Title == "The Shawshank Redemption");
    }

    [Fact]
    public async Task Should_get_specific_film_by_id()
    {
        var response = await _client.GetAsync("/api/film/1");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        var film = JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions 
        { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        });
        
        Assert.NotNull(film);
        Assert.Equal("The Shawshank Redemption", film.Title);
        Assert.Equal("Frank Darabont", film.Director);
    }

    [Fact]
    public async Task Should_return_404_for_nonexistent_film()
    {
        var response = await _client.GetAsync("/api/film/999");
        
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Should_create_new_film()
    {
        var newFilm = new { Title = "Inception", Director = "Christopher Nolan", Year = 2010 };
        var json = JsonSerializer.Serialize(newFilm);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/api/film", content);
        
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(response.Headers.Location);
    }
}



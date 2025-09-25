using FilmDb.Application.Port.Out;
using FilmDb.Domain;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace FilmDb.Application;

public class FilmServiceTest
{
    private readonly IFilmRepository _mockRepository;
    private readonly FilmService _service;


    public FilmServiceTest()
    {
        _mockRepository = Substitute.For<IFilmRepository>();
        _service = new FilmService(_mockRepository);
    }

    [Fact]
    public void LoadFilms_ShouldReturnAllFilms_WhenRepositoryContainsFilms()
    {
        var expectedFilms = new List<Film>
        {
            new(1, "Test Film 1", "Director 1", 2023),
            new(2, "Test Film 2", "Director 2", 2024)
        };
        _mockRepository.FindAllFilms().Returns(expectedFilms);

        var result = _service.GetFilms();

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expectedFilms);
        _mockRepository.Received(1).FindAllFilms();
    }

    [Fact]
    public void LoadFilmById_ShouldReturnFilm_WhenFilmExists()
    {
        var expectedFilm = new Film(1, "Test Film", "Test Director", 2023);
        _mockRepository.FindFilmById(1).Returns(expectedFilm);

        var result = _service.GetFilmById(1);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedFilm);
        _mockRepository.Received(1).FindFilmById(1);
    }
}
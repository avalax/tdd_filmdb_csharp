using FilmDb.Domain;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace FilmDb.Adapter.Out.Persistence;

public class FilmPersistenceAdapterTests
{
    private readonly IFilmRepository _mockRepository;
    private readonly FilmPersistenceAdapter _adapter;

    public FilmPersistenceAdapterTests()
    {
        _mockRepository = Substitute.For<IFilmRepository>();
        _adapter = new FilmPersistenceAdapter(_mockRepository);
    }

    [Fact]
    public void LoadFilms_ShouldReturnAllFilms_WhenRepositoryContainsFilms()
    {
        var expectedFilms = new List<Film>
        {
            new() { Id = 1, Title = "Test Film 1", Director = "Director 1", Year = 2023 },
            new() { Id = 2, Title = "Test Film 2", Director = "Director 2", Year = 2024 }
        };
        _mockRepository.GetAllFilms().Returns(expectedFilms);
        
        var result = _adapter.LoadFilms();
        
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expectedFilms);
        _mockRepository.Received(1).GetAllFilms();
    }

    [Fact]
    public void LoadFilmById_ShouldReturnFilm_WhenFilmExists()
    {
        var expectedFilm = new Film { Id = 1, Title = "Test Film", Director = "Test Director", Year = 2023 };
        _mockRepository.GetFilmById(1).Returns(expectedFilm);
        
        var result = _adapter.LoadFilmById(1);
        
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedFilm);
        _mockRepository.Received(1).GetFilmById(1);
    }
}
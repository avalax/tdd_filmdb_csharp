using FilmDb.Domain;

namespace FilmDb.Adapter.Out.Persistence;

public class StaticFilmRepository : IFilmRepository
{
    public List<Film> GetAllFilms()
    {
        return new List<Film>
        {
            new() { Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", Year = 1994 },
            new() { Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972 },
            new() { Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008 }
        };
    }

    public Film? GetFilmById(int id)
    {
       return GetAllFilms().FirstOrDefault(f => f.Id == id);
    }
}
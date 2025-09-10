using FilmDb.Application.Port.Out;
using FilmDb.Domain;

namespace FilmDb.Adapter.Out.Persistence;

public class StaticFilmRepository : IFilmRepository
{
    public List<Film> FindAllFilms()
    {
        return
        [
            new Film { Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", Year = 1994 },
            new Film { Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972 },
            new Film { Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008 }
        ];
    }

    public Film? FindFilmById(int id)
    {
       return FindAllFilms().FirstOrDefault(f => f.Id == id);
    }
}
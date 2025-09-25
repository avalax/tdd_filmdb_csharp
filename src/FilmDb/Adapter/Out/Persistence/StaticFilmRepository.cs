using FilmDb.Application.Port.Out;
using FilmDb.Domain;

namespace FilmDb.Adapter.Out.Persistence;

public class StaticFilmRepository : IFilmRepository
{
    public List<Film> FindAllFilms()
    {
        return
        [
            new Film(1, "The Shawshank Redemption", "Frank Darabont", 1994),
            new Film(2, "The Godfather", "Francis Ford Coppola", 1972),
            new Film(3, "The Dark Knight", "Christopher Nolan", 2008)
        ];
    }

    public Film? FindFilmById(int id)
    {
        return FindAllFilms().FirstOrDefault(f => f.Id == id);
    }
}
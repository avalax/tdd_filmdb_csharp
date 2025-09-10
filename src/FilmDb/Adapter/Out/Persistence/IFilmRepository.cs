using FilmDb.Domain;

namespace FilmDb.Adapter.Out.Persistence;

public interface IFilmRepository
{
    List<Film> GetAllFilms();
    Film? GetFilmById(int id);
}
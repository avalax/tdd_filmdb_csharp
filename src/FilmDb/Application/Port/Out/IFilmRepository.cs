using FilmDb.Domain;

namespace FilmDb.Application.Port.Out;

public interface IFilmRepository
{
    List<Film> FindAllFilms();
    Film? FindFilmById(int id);
}
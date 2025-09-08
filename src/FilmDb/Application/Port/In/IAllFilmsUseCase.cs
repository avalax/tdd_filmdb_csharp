using FilmDb.Domain;

namespace FilmDb.Application.Port.In;

public interface IAllFilmsUseCase
{
    List<Film> GetFilms();
}
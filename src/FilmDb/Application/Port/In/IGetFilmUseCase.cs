using FilmDb.Domain;

namespace FilmDb.Application.Port.In;

public interface IGetFilmUseCase
{
    Film? GetFilmById(int id);
}
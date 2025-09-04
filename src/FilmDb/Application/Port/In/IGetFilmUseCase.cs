using FilmDb.Domain;

namespace FilmDb.Application.Port.In;

public interface IGetFilmUseCase
{
    List<Film> GetFilms();
    
    Film? GetFilmById(int id);
}
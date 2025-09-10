using FilmDb.Application.Port.In;
using FilmDb.Application.Port.Out;
using FilmDb.Domain;

namespace FilmDb.Application;

public class FilmService(IFilmRepository filmRepository): IGetFilmUseCase, IAllFilmsUseCase, ISaveFilmUseCase
{
    public List<Film> GetFilms()
    {
        return filmRepository.FindAllFilms();
    }

    public Film? GetFilmById(int id)
    {
        return filmRepository.FindFilmById(id);
    }
}
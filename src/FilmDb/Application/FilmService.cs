using FilmDb.Application.Port.In;
using FilmDb.Application.Port.Out;
using FilmDb.Domain;

namespace FilmDb.Application;

public class FilmService(ILoadAllFilmsPort loadAllFilmsPort, ILoadFilmPort loadFilmPort, ISaveFilmPort saveFilmPort): IGetFilmUseCase, IAllFilmsUseCase, ISaveFilmUseCase
{
    public List<Film> GetFilms()
    {
        return loadAllFilmsPort.LoadFilms();
    }

    public Film? GetFilmById(int id)
    {
        return loadFilmPort.LoadFilmById(id);
    }
}
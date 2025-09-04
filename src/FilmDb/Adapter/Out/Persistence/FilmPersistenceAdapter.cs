using FilmDb.Application.Port.Out;
using FilmDb.Domain;

namespace FilmDb.Adapter.Out.Persistence;

public class FilmPersistenceAdapter(StaticFilmRepository staticFilmRepository) : ILoadAllFilmsPort, ILoadFilmPort, ISaveFilmPort
{
    public List<Film> LoadFilms()
    {
        return staticFilmRepository.GetAllFilms();
    }

    public Film? LoadFilmById(int id)
    {
        return staticFilmRepository.GetFilmById(id);
    }
}
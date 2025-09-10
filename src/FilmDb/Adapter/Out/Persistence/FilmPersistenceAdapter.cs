using FilmDb.Application.Port.Out;
using FilmDb.Domain;

namespace FilmDb.Adapter.Out.Persistence;

public class FilmPersistenceAdapter(IFilmRepository filmRepository) : ILoadAllFilmsPort, ILoadFilmPort, ISaveFilmPort
{
    public List<Film> LoadFilms()
    {
        return filmRepository.GetAllFilms();
    }

    public Film? LoadFilmById(int id)
    {
        return filmRepository.GetFilmById(id);
    }
}
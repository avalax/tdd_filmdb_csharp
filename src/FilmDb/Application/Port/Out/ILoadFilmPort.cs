using FilmDb.Domain;

namespace FilmDb.Application.Port.Out;

public interface ILoadFilmPort
{
    public Film? LoadFilmById(int id);
}
using FilmDb.Domain;

namespace FilmDb.Application.Port.Out;

public interface ILoadAllFilmsPort
{
    public List<Film> LoadFilms();
}
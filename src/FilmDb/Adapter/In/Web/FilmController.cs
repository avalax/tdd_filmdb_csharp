using FilmDb.Application.Port.In;
using FilmDb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FilmDb.Adapter.In.Web;

[ApiController]
[Route("api/[controller]")]
public class FilmController(IGetFilmUseCase getFilmUseCase) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Film>> GetAllFilms()
    {
        return Ok(getFilmUseCase.GetFilms());
    }

    [HttpGet("{id}")]
    public ActionResult<Film> GetFilm(int id)
    {
        var film = getFilmUseCase.GetFilmById(id);
        if (film == null)
        {
            return NotFound();
        }

        return Ok(film);
    }

    [HttpPost]
    public ActionResult<Film> CreateFilm([FromBody] CreateFilmRequest request)
    {
        var film = new Film 
        { 
            Id = Random.Shared.Next(1000, 9999),
            Title = request.Title, 
            Director = request.Director, 
            Year = request.Year 
        };
        
        return CreatedAtAction(nameof(GetFilm), new { id = film.Id }, film);
    }
}



public record CreateFilmRequest(string Title, string Director, int Year);
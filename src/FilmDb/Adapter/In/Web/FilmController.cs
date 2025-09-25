using FilmDb.Application.Port.In;
using FilmDb.Domain;
using FilmDb.Adapter.In.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FilmDb.Adapter.In.Web;

[ApiController]
[Route("api/[controller]")]
public class FilmController(IGetFilmUseCase getFilmUseCase, IAllFilmsUseCase allFilmsUseCase) : ControllerBase
{
    /// <summary>
    /// Gets all films in the database
    /// </summary>
    /// <returns>A list of all films</returns>
    /// <response code="200">Returns the list of films</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Film>> GetAllFilms()
    {
        return Ok(allFilmsUseCase.GetFilms());
    }

    /// <summary>
    /// Gets a specific film by ID
    /// </summary>
    /// <param name="id">The ID of the film to retrieve</param>
    /// <returns>The film with the specified ID</returns>
    /// <response code="200">Returns the requested film</response>
    /// <response code="404">If the film is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Film> GetFilm(int id)
    {
        var film = getFilmUseCase.GetFilmById(id);
        if (film == null)
        {
            return NotFound();
        }

        return Ok(film);
    }

    /// <summary>
    /// Creates a new film
    /// </summary>
    /// <param name="request">The film creation request containing title, director, and year</param>
    /// <returns>The newly created film</returns>
    /// <response code="201">Returns the newly created film</response>
    /// <response code="400">If the request is invalid</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Film> CreateFilm([FromBody] CreateFilmRequest request)
    {
        var film = new Film
        (
            Random.Shared.Next(1000, 9999),
            request.Title,
            request.Director,
            request.Year
        );

        return CreatedAtAction(nameof(GetFilm), new { id = film.Id }, film);
    }
}
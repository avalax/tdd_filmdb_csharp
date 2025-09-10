using System.ComponentModel.DataAnnotations;

namespace FilmDb.Adapter.In.Web.Models;

/// <summary>
/// Request model for creating a new film
/// </summary>
/// <param name="Title">The title of the film</param>
/// <param name="Director">The director of the film</param>
/// <param name="Year">The year the film was released</param>
public record CreateFilmRequest(
    [Required] [MaxLength(100)] string Title, 
    [Required] [MaxLength(50)] string Director, 
    [Range(1900, 2100)] int Year);
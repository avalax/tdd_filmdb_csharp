namespace FilmDb.Domain;

public record Film
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int Year { get; set; }
}

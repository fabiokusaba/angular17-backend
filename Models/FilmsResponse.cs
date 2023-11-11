namespace FilmesApi.Models;

public record FilmsResponse(Guid id, string name, string genre, double rate);
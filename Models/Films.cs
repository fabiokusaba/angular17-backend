namespace FilmesApi.Models;

public class Films
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public double Rate { get; set; }

    public Films(string name, string genre, double rate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Genre = genre;
        Rate = rate;
    }
}
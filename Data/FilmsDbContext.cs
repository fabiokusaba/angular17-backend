using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmsDbContext : DbContext
{
    public DbSet<Films> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5433;Database=films_db;User Id=postgres;Password=ty2503;"
            );
        base.OnConfiguring(optionsBuilder);
    }
}
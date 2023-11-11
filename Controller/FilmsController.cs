using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controller;

public static class FilmsController
{
    public static void FilmsRoutes(this WebApplication app)
    {
        var filmsRoutes = app.MapGroup("/films");

        filmsRoutes.MapPost("", async (FilmsRequest request, FilmsDbContext context, CancellationToken ct) =>
        {
            var filmExists = await context.Films.AnyAsync(film => film.Name == request.name, ct);

            if (filmExists)
            {
                return Results.Conflict("Filme já cadastrado no banco.");
            }

            var newFilm = new Films(request.name, request.genre, request.rate);

            await context.Films.AddAsync(newFilm, ct);
            await context.SaveChangesAsync(ct);

            var response = new FilmsResponse(newFilm.Id, newFilm.Name, newFilm.Genre, newFilm.Rate);
            return Results.Created("Filme cadastrado com sucesso", response);
        });

        filmsRoutes.MapGet("", async (FilmsDbContext context, CancellationToken ct) =>
        {
            var films = await context.Films
                .Select(film => new FilmsResponse(film.Id, film.Name, film.Genre, film.Rate))
                .ToListAsync(ct);

            return Results.Ok(films);
        });

        filmsRoutes.MapPut("{id}", async (Guid id, FilmsRequest request, FilmsDbContext context, CancellationToken ct) =>
        {
            var film = await context.Films.FirstOrDefaultAsync(film => film.Id == id, ct);

            if (film == null)
            {
                return Results.NotFound("Filme não encontrado.");
            }

            film.Name = request.name;
            film.Genre = request.genre;
            film.Rate = request.rate;

            await context.SaveChangesAsync(ct);

            return Results.Ok(new FilmsResponse(film.Id, film.Name, film.Genre, film.Rate));
        });

        filmsRoutes.MapDelete("{id}", async (Guid id, FilmsDbContext context, CancellationToken ct) =>
        {
            var film = await context.Films.FirstOrDefaultAsync(film => film.Id == id, ct);

            if (film == null)
            {
                return Results.NotFound("Filme não encontrado.");
            }

            context.Films.Remove(film);
            await context.SaveChangesAsync(ct);

            return Results.Ok();
        });
    }
}
using System;
using WebApplication1.Dtos;

namespace WebApplication1.Endpoints;

public static class GameEndpoints
{
    private static string GetGameEndpointName = "GetGame";
    private static List<GameDto> games = [
        new(
            1,
            "Zombies",
            2021,
            12.3m
        ),
        new(
            2,
            "Angry Birds",
            2009,
            18.97m
        ),
        new(
            3,
            "MK",
            1998,
            4.3m
        )
    ];

    public static RouteGroupBuilder MapGameEndpoints (this WebApplication app)
    {   
        var group = app.MapGroup("games")
                        .WithParameterValidation();

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

        group.MapPost("", (CreateGameDto newGame) =>
        {
            GameDto game = new (
                games.Count + 1,
                newGame.Name,
                newGame.Year,
                newGame.Price
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            int index = games.FindIndex(game => game.Id == id);

            games[index] = new(
                id,
                updatedGame.Name,
                updatedGame.Year,
                updatedGame.Price
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll((game) => game.Id == id);
            
            return Results.NoContent();
        });
        
        return group;
    }
}

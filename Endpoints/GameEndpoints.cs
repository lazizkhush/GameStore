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

    public static WebApplication MapGameEndpoints (this WebApplication app)
    {   
        app.MapGet("/games", () => games);

        app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

        app.MapPost("games", (CreateGameDto newGame) =>
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

        app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
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

        app.MapDelete("/games/{id}", (int id) =>
        {
            games.RemoveAll((game) => game.Id == id);
            
            return Results.NoContent();
        });
        
        return app;
    }
}

namespace WebApplication1.Dtos;

public record class CreateGameDto(
    string Name,
    int Year,
    decimal Price
);
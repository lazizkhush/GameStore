namespace WebApplication1.Dtos;

public record class GameDto(
    int Id,
    string Name,
    string Genre,
    DateOnly Year,
    decimal Price
);

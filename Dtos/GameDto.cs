namespace WebApplication1.Dtos;

public record class GameDto(
    int Id,
    string Name,
    int Year,
    decimal Price
);

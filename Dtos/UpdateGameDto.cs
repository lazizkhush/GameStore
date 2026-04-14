namespace WebApplication1.Dtos;

public record class UpdateGameDto(
    string Name,
    int Year,
    decimal Price
);

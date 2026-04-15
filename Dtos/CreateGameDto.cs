using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    int Year,
    [Required][Range(1, 100)] decimal Price
);
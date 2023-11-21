using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class CreateCinemaDTO
{
    [Required(ErrorMessage = "O nome do Cinema é obrigatório.")]
    public string Name { get; set; }
}

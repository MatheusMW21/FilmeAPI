using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O gênero excedeu o limite de caracteres permitidos")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "O ano de lançamento do filme é obrigatório")]
    [Range(0, 3000, ErrorMessage = "Insira um ano válido.")]
    public int AnoLancamento { get; set; }
    [Required]
    [Range(70, 600, ErrorMessage = "A duração excedeu o limite de minutos permitidos")]
    public int Duracao { get; set; }
    public string Diretor { get; set; }
}

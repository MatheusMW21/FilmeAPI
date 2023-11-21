using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs;

public class ReadMovieDTO
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int AnoLancamento { get; set; }
    public int Duracao { get; set; }
    public string Diretor { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}

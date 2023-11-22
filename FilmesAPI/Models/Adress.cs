using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Adress
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; }
}

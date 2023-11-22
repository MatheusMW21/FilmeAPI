using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do Cinema é obrigatório.")] 
    public string Name { get; set; }
    public int AdressId { get; set; }
    public virtual Adress Adress { get; set; }
}

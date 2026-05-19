using System.ComponentModel.DataAnnotations;

namespace Apbd_Task_CodeFirst.Models;

public class ComponentTypes
{
    [Key] public int Id { get; set; }
    [Required] public string Abbreviation { get; set; } = null!;
    [Required] public string Name { get; set; } = null!;

    public ICollection<Components> Components { get; set; } = null!;
}
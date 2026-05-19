using System.ComponentModel.DataAnnotations;

namespace Apbd_Task_CodeFirst.Models;

public class ComponentManufacturers
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;
    [MaxLength(300)]
    public string FullName { get; set; } = null!;
    public DateOnly FoundationDate { get; set; }

    public ICollection<Components> Components { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd_Task_CodeFirst.Models;

public class Components
{
    [Key] 
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    [Required] [MaxLength(30)] public string Name { get; set; } = null!;

    [MaxLength] public string Description { get; set; } = null!;


    public int ComponentManufacturerId { get; set; }

    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacturers ComponentManufacturer { get; set; }

    public int ComponentTypeId { get; set; }
    [ForeignKey(nameof(ComponentTypeId))] public ComponentTypes ComponentType { get; set; }


    public ICollection<PCComponents> PcComponents { get; set; } = null!;
}
using System.ComponentModel;

namespace Apbd_Task_CodeFirst.Models;

public class PCs
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public ICollection<PCComponents> PcComponents { get; set; } = null!;
}
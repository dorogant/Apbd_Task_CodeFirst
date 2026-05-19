using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apbd_Task_CodeFirst.Models;

public class PCComponents
{
    public int PcId { get; set; }

    [MaxLength(10)]
    public string ComponentCode { get; set; } = null!;

    public PCs Pc { get; set; } = null!;
    public Components Component { get; set; } = null!;

    public int Amount { get; set; }
}
using Apbd_Task_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apbd_Task_CodeFirst.DAL.Configurations;

public class PCComponentsEntityTypeConfiguration : IEntityTypeConfiguration<PCComponents>
{
    public void Configure(EntityTypeBuilder<PCComponents> builder)
    {
        builder.HasKey(e => new { e.PcId, e.ComponentCode });
        
        builder.HasOne(e => e.Pc)
            .WithMany(p => p.PcComponents)
            .HasForeignKey(e => e.PcId);
        builder.HasOne(e => e.Component)
            .WithMany(p => p.PcComponents)
            .HasForeignKey(e => e.ComponentCode);
    }
}
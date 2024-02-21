using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts.Configurations
{
    public class MonthConfiguration : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.HasKey(e => e.IdMonth).HasName("pk_Month");

            builder.ToTable("months");

            builder.HasIndex(e => e.NameMonth, "UQ__months__D4660E30D25BC707").IsUnique();

            builder.Property(e => e.IdMonth).HasColumnName("idMonth");
            builder.Property(e => e.NameMonth)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nameMonth");
        }
    }
}

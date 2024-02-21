using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts.Configurations
{
    public class AdditionalTomaConfiguration : IEntityTypeConfiguration<AdditionalToma>
    {
        public void Configure(EntityTypeBuilder<AdditionalToma> builder)
        {
            builder.HasKey(e => e.IdAdditionalToma).HasName("pk_additionalTomaToma");

            builder.ToTable("additionalToma");

            builder.Property(e => e.IdAdditionalToma).HasColumnName("idAdditionalToma");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.DescriptionToma)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("('S/C')")
                .HasColumnName("descriptionToma");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.IdConsumer).HasColumnName("idConsumer");
            builder.Property(e => e.IdStatusToma).HasColumnName("idStatusToma");
            builder.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            builder.Property(e => e.IdToma).HasColumnName("idToma");

            builder.HasOne(d => d.IdConsumerNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdConsumer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalTomaConsumer");

            builder.HasOne(d => d.IdStatusTomaNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdStatusToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalTomatatusToma");

            builder.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalTomaTarifa");

            builder.HasOne(d => d.IdTomaNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalToma");
        }
    }
}

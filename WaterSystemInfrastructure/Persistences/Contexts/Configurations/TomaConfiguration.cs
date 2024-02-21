using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts.Configurations
{
    public class TomaConfiguration : IEntityTypeConfiguration<Toma>
    {
        public void Configure(EntityTypeBuilder<Toma> builder)
        {

            builder.HasKey(e => e.IdToma).HasName("pk_toma");

            builder.ToTable("toma");

            builder.Property(e => e.IdToma).HasColumnName("idToma");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.DescripcionToma)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcionToma");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.IdContract).HasColumnName("idContract");
            builder.Property(e => e.IdSettlement).HasColumnName("idSettlement");
            builder.Property(e => e.IdStatusToma).HasColumnName("idStatusToma");
            builder.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            builder.Property(e => e.Idstreet).HasColumnName("idstreet");

            builder.HasOne(d => d.IdContractNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_tomaContracto");

            builder.HasOne(d => d.IdSettlementNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdSettlement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_tomaColonia");

            builder.HasOne(d => d.IdStatusTomaNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdStatusToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_tomastatusToma");

            builder.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_contriTarifa");

            builder.HasOne(d => d.IdstreetNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.Idstreet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_fkContriStreet");
        }
    }
}

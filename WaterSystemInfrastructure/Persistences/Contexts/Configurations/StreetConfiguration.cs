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
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.HasKey(e => e.Idstreet).HasName("pk_street");

            builder.ToTable("street");

            builder.Property(e => e.Idstreet).HasColumnName("idstreet");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.IdSettlement).HasColumnName("idSettlement");
            builder.Property(e => e.NameStreet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameStreet");

            builder.HasOne(d => d.IdSettlementNavigation).WithMany(p => p.Streets)
                .HasForeignKey(d => d.IdSettlement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_settlement");
        }
    }
}

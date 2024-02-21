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
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(e => e.IdCargo).HasName("pk_cargo");

            builder.ToTable("cargo");

            builder.Property(e => e.IdCargo).HasColumnName("idCargo");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("description");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.StatusCargos)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusCargos");
        }
    }
}

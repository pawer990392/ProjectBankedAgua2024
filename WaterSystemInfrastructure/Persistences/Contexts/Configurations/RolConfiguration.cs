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
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(e => e.IdRol).HasName("pk_rol");

            builder.ToTable("rol");

            builder.Property(e => e.IdRol).HasColumnName("idRol");
            builder.Property(e => e.DateCreate)
                .HasColumnType("date")
                .HasColumnName("date_create");
            builder.Property(e => e.DateModifity)
                .HasColumnType("date")
                .HasColumnName("date_modifity");
            builder.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("description");
            builder.Property(e => e.StatusRol)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusRol");
        }
    }
}

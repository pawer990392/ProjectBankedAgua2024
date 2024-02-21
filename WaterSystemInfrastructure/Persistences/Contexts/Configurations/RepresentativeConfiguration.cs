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
    public class RepresentativeConfiguration : IEntityTypeConfiguration<Representative>
    {
        public void Configure(EntityTypeBuilder<Representative> builder)
        {
            builder.HasKey(e => e.IdRepresentative).HasName("pk_representative");

            builder.ToTable("representative");

            builder.Property(e => e.IdRepresentative).HasColumnName("idRepresentative");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.IdCargo).HasColumnName("idCargo");
            builder.Property(e => e.LastNameM)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameM");
            builder.Property(e => e.LastNameP)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameP");
            builder.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            builder.Property(e => e.StatusRepresentative)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusRepresentative");

            builder.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Representatives)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cargo");
        }
    }
}

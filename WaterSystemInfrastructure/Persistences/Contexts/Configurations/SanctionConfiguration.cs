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
    public class SanctionConfiguration : IEntityTypeConfiguration<Sanction>
    {
        public void Configure(EntityTypeBuilder<Sanction> builder)
        {
            builder.HasKey(e => e.IdSanction).HasName("pk_idSanction");

            builder.ToTable("sanction");

            builder.Property(e => e.IdSanction).HasColumnName("idSanction");
            builder.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.StatusSancion)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusSancion");
        }
    }
}

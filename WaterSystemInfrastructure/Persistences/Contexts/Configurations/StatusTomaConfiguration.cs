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
    public class StatusTomaConfiguration : IEntityTypeConfiguration<StatusToma>
    {
        public void Configure(EntityTypeBuilder<StatusToma> builder)
        {
            builder.HasKey(e => e.IdStatusToma).HasName("pk_statusToma");

            builder.ToTable("statusToma");

            builder.Property(e => e.IdStatusToma).HasColumnName("idStatusToma");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("description");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.StatusToma1)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusToma");
        }
    }
}

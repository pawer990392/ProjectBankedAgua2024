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
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(e => e.IdContract).HasName("pk_Contract");

            builder.ToTable("contract");

            builder.Property(e => e.IdContract).HasColumnName("idContract");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.IdConsumer).HasColumnName("idConsumer");
            builder.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            builder.Property(e => e.Idservices).HasColumnName("idservices");

            builder.HasOne(d => d.IdConsumerNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdConsumer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_ContractConsumer");

            builder.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_ContractTarifa");

            builder.HasOne(d => d.IdservicesNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Idservices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_ContractServices");
        }
    }
}

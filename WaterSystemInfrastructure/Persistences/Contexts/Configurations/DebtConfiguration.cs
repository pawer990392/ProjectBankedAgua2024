using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts.Configurations
{
    public class DebtConfiguration : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> builder)
        {
            builder.HasKey(e => e.IdDebts).HasName("pk_idDebts");

            builder.ToTable("debts");

            builder.Property(e => e.IdDebts).HasColumnName("idDebts");
            builder.Property(e => e.CreateDebts)
                .HasColumnType("datetime")
                .HasColumnName("createDebts");
            builder.Property(e => e.ExpiredYear).HasColumnName("expiredYear");
            builder.Property(e => e.IdSanction).HasColumnName("idSanction");
            builder.Property(e => e.IdToma).HasColumnName("idToma");
            builder.Property(e => e.IdexpiredMonth).HasColumnName("idexpiredMonth");
            builder.Property(e => e.StatusPay).HasColumnName("statusPay");

            builder.HasOne(d => d.IdSanctionNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdSanction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DebtsSanction");

            builder.HasOne(d => d.IdTomaNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DebtsToma");

            builder.HasOne(d => d.IdexpiredMonthNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdexpiredMonth)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DebtsExpireMonth");
        }
    }
}

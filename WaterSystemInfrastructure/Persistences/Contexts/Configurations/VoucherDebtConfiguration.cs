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
    public class VoucherDebtConfiguration : IEntityTypeConfiguration<VoucherDebt>
    {
        public void Configure(EntityTypeBuilder<VoucherDebt> builder)
        {
            builder.HasKey(e => new { e.IdVoucher, e.IdDebts }).HasName("pk_voucherDebts");

            builder.ToTable("voucher_debts");

            builder.Property(e => e.IdVoucher).HasColumnName("idVoucher");
            builder.Property(e => e.IdDebts).HasColumnName("idDebts");
            builder.Property(e => e.DebtsPaidDate)
                .HasColumnType("datetime")
                .HasColumnName("debtsPaidDate");

            builder.HasOne(d => d.IdDebtsNavigation).WithMany(p => p.VoucherDebts)
                .HasForeignKey(d => d.IdDebts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_debtsDetail");

            builder.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.VoucherDebts)
                .HasForeignKey(d => d.IdVoucher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_voucherDetail");
        }
    }
}

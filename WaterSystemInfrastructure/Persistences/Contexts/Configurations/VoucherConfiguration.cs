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
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(e => e.IdVoucher).HasName("pk_voucher");

            builder.ToTable("voucher");

            builder.Property(e => e.IdVoucher).HasColumnName("idVoucher");
            builder.Property(e => e.AmountPay)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("amountPay");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.IdToma).HasColumnName("idToma");
            builder.Property(e => e.YearPagado).HasColumnName("yearPagado");

            builder.HasOne(d => d.IdTomaNavigation).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.IdToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_voucherTomas");

            builder.HasMany(d => d.IdMonths).WithMany(p => p.Idvouchers)
                .UsingEntity<Dictionary<string, object>>(
                    "VoucherMese",
                    r => r.HasOne<Month>().WithMany()
                        .HasForeignKey("IdMonth")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_detailMonth"),
                    l => l.HasOne<Voucher>().WithMany()
                        .HasForeignKey("Idvoucher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_voucher_detail"),
                    j =>
                    {
                        j.HasKey("Idvoucher", "IdMonth").HasName("pk_voucherMonth");
                        j.ToTable("voucher_meses");
                        j.IndexerProperty<int>("Idvoucher").HasColumnName("idvoucher");
                        j.IndexerProperty<int>("IdMonth").HasColumnName("idMonth");
                    });
        }
    }
}

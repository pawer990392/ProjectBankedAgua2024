using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WaterSystem.Domain.MyEntidades;

public partial class SistemasCobroAgua2024Context : DbContext
{
    public SistemasCobroAgua2024Context()
    {
    }

    public SistemasCobroAgua2024Context(DbContextOptions<SistemasCobroAgua2024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalToma> AdditionalTomas { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Consumer> Consumers { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Debt> Debts { get; set; }

    public virtual DbSet<Month> Months { get; set; }

    public virtual DbSet<Representative> Representatives { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sanction> Sanctions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Settlement> Settlements { get; set; }

    public virtual DbSet<StatusToma> StatusTomas { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<Toma> Tomas { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherDebt> VoucherDebts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MiguelAngel;Initial Catalog=SistemasCobroAgua2024;Integrated Security=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalToma>(entity =>
        {
            entity.HasKey(e => e.IdAdditionalToma).HasName("pk_additionalTomaToma");

            entity.ToTable("additionalToma");

            entity.Property(e => e.IdAdditionalToma).HasColumnName("idAdditionalToma");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.DescriptionToma)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("('S/C')")
                .HasColumnName("descriptionToma");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.IdConsumer).HasColumnName("idConsumer");
            entity.Property(e => e.IdStatusToma).HasColumnName("idStatusToma");
            entity.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            entity.Property(e => e.IdToma).HasColumnName("idToma");

            entity.HasOne(d => d.IdConsumerNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdConsumer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalTomaConsumer");

            entity.HasOne(d => d.IdStatusTomaNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdStatusToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalTomatatusToma");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalTomaTarifa");

            entity.HasOne(d => d.IdTomaNavigation).WithMany(p => p.AdditionalTomas)
                .HasForeignKey(d => d.IdToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_additionalToma");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("pk_cargo");

            entity.ToTable("cargo");

            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.StatusCargos)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusCargos");
        });

        modelBuilder.Entity<Consumer>(entity =>
        {
            entity.HasKey(e => e.IdConsumer).HasName("pk_Consumer");

            entity.ToTable("consumer");

            entity.Property(e => e.IdConsumer).HasColumnName("idConsumer");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasDefaultValueSql("('/')")
                .HasColumnName("descripcion");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.Idstreet).HasColumnName("idstreet");
            entity.Property(e => e.LastNameM)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameM");
            entity.Property(e => e.LastNameP)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameP");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NumberExt).HasColumnName("numberExt");
            entity.Property(e => e.NumberInt)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('/')")
                .HasColumnName("numberInt");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.TypeGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typeGender");

            entity.HasOne(d => d.IdstreetNavigation).WithMany(p => p.Consumers)
                .HasForeignKey(d => d.Idstreet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consumerStreet");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract).HasName("pk_Contract");

            entity.ToTable("contract");

            entity.Property(e => e.IdContract).HasColumnName("idContract");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.IdConsumer).HasColumnName("idConsumer");
            entity.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            entity.Property(e => e.Idservices).HasColumnName("idservices");

            entity.HasOne(d => d.IdConsumerNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdConsumer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_ContractConsumer");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_ContractTarifa");

            entity.HasOne(d => d.IdservicesNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Idservices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_ContractServices");
        });

        modelBuilder.Entity<Debt>(entity =>
        {
            entity.HasKey(e => e.IdDebts).HasName("pk_idDebts");

            entity.ToTable("debts");

            entity.Property(e => e.IdDebts).HasColumnName("idDebts");
            entity.Property(e => e.CreateDebts)
                .HasColumnType("datetime")
                .HasColumnName("createDebts");
            entity.Property(e => e.ExpiredYear).HasColumnName("expiredYear");
            entity.Property(e => e.IdSanction).HasColumnName("idSanction");
            entity.Property(e => e.IdToma).HasColumnName("idToma");
            entity.Property(e => e.IdexpiredMonth).HasColumnName("idexpiredMonth");
            entity.Property(e => e.StatusPay).HasColumnName("statusPay");

            entity.HasOne(d => d.IdSanctionNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdSanction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DebtsSanction");

            entity.HasOne(d => d.IdTomaNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DebtsToma");

            entity.HasOne(d => d.IdexpiredMonthNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdexpiredMonth)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DebtsExpireMonth");
        });

        modelBuilder.Entity<Month>(entity =>
        {
            entity.HasKey(e => e.IdMonth).HasName("pk_Month");

            entity.ToTable("months");

            entity.HasIndex(e => e.NameMonth, "UQ__months__D4660E30B40ED8CE").IsUnique();

            entity.Property(e => e.IdMonth).HasColumnName("idMonth");
            entity.Property(e => e.NameMonth)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nameMonth");
        });

        modelBuilder.Entity<Representative>(entity =>
        {
            entity.HasKey(e => e.IdRepresentative).HasName("pk_representative");

            entity.ToTable("representative");

            entity.Property(e => e.IdRepresentative).HasColumnName("idRepresentative");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.LastNameM)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameM");
            entity.Property(e => e.LastNameP)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameP");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StatusRepresentative)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusRepresentative");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Representatives)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cargo");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("pk_rol");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.DateCreate)
                .HasColumnType("date")
                .HasColumnName("date_create");
            entity.Property(e => e.DateModifity)
                .HasColumnType("date")
                .HasColumnName("date_modifity");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.StatusRol)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusRol");
        });

        modelBuilder.Entity<Sanction>(entity =>
        {
            entity.HasKey(e => e.IdSanction).HasName("pk_idSanction");

            entity.ToTable("sanction");

            entity.Property(e => e.IdSanction).HasColumnName("idSanction");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.StatusSancion)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusSancion");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Idservices).HasName("pk_Services");

            entity.ToTable("services");

            entity.Property(e => e.Idservices).HasColumnName("idservices");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.StatusServices)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusServices");
        });

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.HasKey(e => e.IdSettlement).HasName("pk_idSettlement");

            entity.ToTable("settlement");

            entity.Property(e => e.IdSettlement).HasColumnName("idSettlement");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StatusToma>(entity =>
        {
            entity.HasKey(e => e.IdStatusToma).HasName("pk_statusToma");

            entity.ToTable("statusToma");

            entity.Property(e => e.IdStatusToma).HasColumnName("idStatusToma");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.StatusToma1)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusToma");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Idstreet).HasName("pk_street");

            entity.ToTable("street");

            entity.Property(e => e.Idstreet).HasColumnName("idstreet");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.IdSettlement).HasColumnName("idSettlement");
            entity.Property(e => e.NameStreet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameStreet");

            entity.HasOne(d => d.IdSettlementNavigation).WithMany(p => p.Streets)
                .HasForeignKey(d => d.IdSettlement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_settlement");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.IdTarifa).HasName("pk_tarifa");

            entity.ToTable("tarifa");

            entity.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.StatusTarifa)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusTarifa");
        });

        modelBuilder.Entity<Toma>(entity =>
        {
            entity.HasKey(e => e.IdToma).HasName("pk_toma");

            entity.ToTable("toma");

            entity.Property(e => e.IdToma).HasColumnName("idToma");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.DescripcionToma)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcionToma");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.IdContract).HasColumnName("idContract");
            entity.Property(e => e.IdSettlement).HasColumnName("idSettlement");
            entity.Property(e => e.IdStatusToma).HasColumnName("idStatusToma");
            entity.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            entity.Property(e => e.Idstreet).HasColumnName("idstreet");

            entity.HasOne(d => d.IdContractNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_tomaContracto");

            entity.HasOne(d => d.IdSettlementNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdSettlement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_tomaColonia");

            entity.HasOne(d => d.IdStatusTomaNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdStatusToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_tomastatusToma");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_contriTarifa");

            entity.HasOne(d => d.IdstreetNavigation).WithMany(p => p.Tomas)
                .HasForeignKey(d => d.Idstreet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pk_fkContriStreet");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("pk_users");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.LastNameM)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameM");
            entity.Property(e => e.LastNameP)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("lastNameP");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StatusUsers)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusUsers");
            entity.Property(e => e.UserName)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userRol");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.IdVoucher).HasName("pk_voucher");

            entity.ToTable("voucher");

            entity.Property(e => e.IdVoucher).HasColumnName("idVoucher");
            entity.Property(e => e.AmountPay)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("amountPay");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreateUser).HasColumnName("createUser");
            entity.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            entity.Property(e => e.EditUser).HasColumnName("editUser");
            entity.Property(e => e.IdToma).HasColumnName("idToma");
            entity.Property(e => e.YearPagado).HasColumnName("yearPagado");

            entity.HasOne(d => d.IdTomaNavigation).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.IdToma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_voucherTomas");

            entity.HasMany(d => d.IdMonths).WithMany(p => p.Idvouchers)
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
        });

        modelBuilder.Entity<VoucherDebt>(entity =>
        {
            entity.HasKey(e => new { e.IdVoucher, e.IdDebts }).HasName("pk_voucherDebts");

            entity.ToTable("voucher_debts");

            entity.Property(e => e.IdVoucher).HasColumnName("idVoucher");
            entity.Property(e => e.IdDebts).HasColumnName("idDebts");
            entity.Property(e => e.DebtsPaidDate)
                .HasColumnType("datetime")
                .HasColumnName("debtsPaidDate");

            entity.HasOne(d => d.IdDebtsNavigation).WithMany(p => p.VoucherDebts)
                .HasForeignKey(d => d.IdDebts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_debtsDetail");

            entity.HasOne(d => d.IdVoucherNavigation).WithMany(p => p.VoucherDebts)
                .HasForeignKey(d => d.IdVoucher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_voucherDetail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts;

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

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=MiguelAngel\\MIGUELADMIN2024;Database=SistemasCobroAgua2024;Trusted_Connection=True;TrustServerCertificate=True");

    //
    //SE ENCARCARHA DE UNIR OCONFIGURAR LAS INTERCALACION DE LA DB
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation","Modern_Spanish_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

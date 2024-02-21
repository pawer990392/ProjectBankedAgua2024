using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts.Configurations
{
    public class ConsumerConfiguration : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.HasKey(e => e.IdConsumer).HasName("pk_Consumer");

            builder.ToTable("consumer");

            builder.Property(e => e.IdConsumer).HasColumnName("idConsumer");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasDefaultValueSql("('/')")
                .HasColumnName("descripcion");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.Idstreet).HasColumnName("idstreet");
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
            builder.Property(e => e.NumberExt).HasColumnName("numberExt");
            builder.Property(e => e.NumberInt)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('/')")
                .HasColumnName("numberInt");
            builder.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            builder.Property(e => e.TypeGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typeGender");

            builder.HasOne(d => d.IdstreetNavigation).WithMany(p => p.Consumers)
                .HasForeignKey(d => d.Idstreet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consumerStreet");
        }
    }
}

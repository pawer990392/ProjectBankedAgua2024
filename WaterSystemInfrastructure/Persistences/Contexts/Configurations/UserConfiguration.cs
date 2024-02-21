using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("pk_users");

            builder.ToTable("users");

            builder.Property(e => e.Id).HasColumnName("idUser");
            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            builder.Property(e => e.CreateUser).HasColumnName("createUser");
            builder.Property(e => e.EditDate)
                .HasColumnType("datetime")
                .HasColumnName("editDate");
            builder.Property(e => e.EditUser).HasColumnName("editUser");
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("email");
            builder.Property(e => e.IdRol).HasColumnName("idRol");
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
            builder.Property(e => e.Password).HasColumnType("text");
            builder.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Property(e => e.StatusUsers)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("statusUsers");
            builder.Property(e => e.UserName)
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userRol");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;
using static TodoList.Models.UserAccount;

namespace TodoList.Mapping;

public class UserAccountMap : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {

        builder.ToTable("UserAccount");

        builder.Property(x => x.Id)
        .HasColumnName("Id")
        .HasColumnType("Int")
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("Nvarchar(130)")
        .IsRequired();

        builder.Property(x => x.Login)
        .HasColumnName("Login")
        .HasColumnType("Nvarchar(100)")
        .IsRequired();

        builder.HasIndex(x => x.Login, "Unique_Key_Login_UserAccount")
        .IsUnique();

        builder.Property(x => x.Password)
        .HasColumnName("PasswordHash")
        .HasColumnType("Nvarchar(255)")
        .IsRequired();

        builder.Property(x => x.Email)
        .HasColumnName("Email")
        .HasColumnType("Nvarchar(130)")
        .IsRequired();

        builder.HasIndex(x => x.Email, "Unique_Key_Email_UserAccount")
        .IsUnique();

        builder.Property(x => x.PhoneNumber)
        .HasColumnName("PhoneNumber")
        .HasColumnType("Nvarchar(20)")
        .IsRequired();

        builder.HasIndex(x => x.PhoneNumber, "Unique_Key_PhoneNumber_UserAccount")
        .IsUnique();

        builder.Property(x => x.BirthDate)
        .HasColumnName("BirthDate")
        .HasColumnType("Smalldatetime")
        .IsRequired();

        builder.Property(x => x.Role)
        .HasColumnName("Role")
        .HasColumnType("Int")
        .IsRequired();

        builder.Property(x => x.Active)
        .HasColumnName("Active")
        .HasColumnType("Bit")
        .IsRequired()
        .HasDefaultValue(true);

        builder.Property(x => x.CreatedAt)
        .HasColumnName("CreatedAt")
        .HasColumnType("Smalldatetime")
        .IsRequired();

    }
}
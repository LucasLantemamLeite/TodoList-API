using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Mapping;

public class TaskItemMap : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {

        builder.ToTable("TaskItems");

        builder.Property(x => x.TaskId)
        .HasColumnName("TaskId")
        .HasColumnType("Int")
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(x => x.Title)
        .HasColumnName("Title")
        .HasColumnType("Nvarchar(100)")
        .IsRequired();

        builder.Property(x => x.Description)
        .HasColumnName("Description")
        .HasColumnType("Nvarchar(300)");

        builder.Property(x => x.Done)
        .HasColumnName("Done")
        .HasColumnType("Bit")
        .HasDefaultValue(false);

        builder.Property(x => x.CreatedAt)
        .HasColumnName("CreatedAt")
        .HasColumnType("Smalldatetime")
        .IsRequired();

        builder.Property(x => x.DeadLine)
        .HasColumnName("DeadLine")
        .HasColumnType("Smalldatetime");

        builder.Property(x => x.CompleteDate)
        .HasColumnName("Complete Date")
        .HasColumnType("Smalldatetime");

        builder.Property(x => x.UserId)
        .HasColumnName("UserId")
        .HasColumnType("Int")
        .IsRequired();

        builder.HasOne(x => x.UserAccount)
        .WithMany(x => x.TaskItems)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class UniquePhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserAccount",
                type: "Int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "Int");

            migrationBuilder.CreateIndex(
                name: "Unique_Key_PhoneNumber_UserAccount",
                table: "UserAccount",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unique_Key_PhoneNumber_UserAccount",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserAccount",
                type: "Int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "Int",
                oldDefaultValue: 2);
        }
    }
}

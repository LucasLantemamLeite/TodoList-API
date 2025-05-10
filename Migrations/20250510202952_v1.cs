using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Nvarchar(130)", nullable: false),
                    Login = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    PasswordHash = table.Column<string>(type: "Nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "Nvarchar(130)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "Nvarchar(20)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Smalldatetime", nullable: false),
                    Role = table.Column<int>(type: "Int", nullable: false, defaultValue: 2),
                    Active = table.Column<bool>(type: "Bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "Smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "Nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(300)", nullable: true),
                    Done = table.Column<bool>(type: "Bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "Smalldatetime", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "Smalldatetime", nullable: true),
                    CompleteDate = table.Column<DateTime>(name: "Complete Date", type: "Smalldatetime", nullable: true),
                    UserId = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskItems_UserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Unique_Key_Email_UserAccount",
                table: "UserAccount",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_Key_Login_UserAccount",
                table: "UserAccount",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_Key_PhoneNumber_UserAccount",
                table: "UserAccount",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}

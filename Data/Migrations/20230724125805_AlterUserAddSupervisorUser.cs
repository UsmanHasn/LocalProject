using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserAddSupervisorUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupervisorUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SupervisorUserId",
                table: "Users",
                column: "SupervisorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_SupervisorUserId",
                table: "Users",
                column: "SupervisorUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_SupervisorUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SupervisorUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SupervisorUserId",
                table: "Users");
        }
    }
}

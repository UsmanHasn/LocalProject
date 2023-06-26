using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "UserProfile",
                newName: "WayNumber");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "UserProfile",
                newName: "BuildingNumber");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumber",
                table: "UserProfile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "WayNumber",
                table: "UserProfile",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "BuildingNumber",
                table: "UserProfile",
                newName: "Address2");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "UserProfile",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}

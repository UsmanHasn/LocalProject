using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterLanguageLookupAddedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "LanguageLookup",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LanguageLookup",
                newName: "EnglishValue");

            migrationBuilder.AddColumn<string>(
                name: "ArabicValue",
                table: "LanguageLookup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicValue",
                table: "LanguageLookup");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "LanguageLookup",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "EnglishValue",
                table: "LanguageLookup",
                newName: "Name");
        }
    }
}

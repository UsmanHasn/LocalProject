using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserAddMissingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CivilNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CivilExpiryDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Towncode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Towndesc_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wilayatcode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Wilayatdesc_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_1_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_2_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_3_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_4_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_5_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_6_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "title_ar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EffFrom",
                table: "UserDelegatedPermissions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffTo",
                table: "UserDelegatedPermissions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CivilExpiryDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Towncode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Towndesc_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Wilayatcode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Wilayatdesc_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name_1_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name_2_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name_3_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name_4_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name_5_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name_6_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "title_ar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EffFrom",
                table: "UserDelegatedPermissions");

            migrationBuilder.DropColumn(
                name: "EffTo",
                table: "UserDelegatedPermissions");

            migrationBuilder.AlterColumn<int>(
                name: "CivilNumber",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

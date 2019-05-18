using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations
{
    public partial class CountriesTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Alpha2Code",
                table: "Countries",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alpha3Code",
                table: "Countries",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Capital",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NativeName",
                table: "Countries",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumericCode",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subregion",
                table: "Countries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alpha2Code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Alpha3Code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Capital",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NativeName",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NumericCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Subregion",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}

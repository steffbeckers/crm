using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations.Identity
{
    public partial class AddingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "179b9251-db56-47c9-8e6e-5f0e63f1fd18", "774fbf98-940c-459c-8283-7e4512c6ffa9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e230e14d-e8c6-46e8-8dd1-b4962dfe8fa1", "288a02df-0d7d-4896-882e-3d1c72b4325b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "179b9251-db56-47c9-8e6e-5f0e63f1fd18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e230e14d-e8c6-46e8-8dd1-b4962dfe8fa1");
        }
    }
}

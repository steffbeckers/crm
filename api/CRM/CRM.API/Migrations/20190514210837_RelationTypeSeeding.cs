using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations
{
    public partial class RelationTypeSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RelationType",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { new Guid("0e8ba1b4-0382-4a39-bb0d-2f654a1f1abc"), "Customer", "customer" });

            migrationBuilder.InsertData(
                table: "RelationType",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { new Guid("5e88157a-3ec0-4c04-9b86-041a07446f12"), "Partner", "partner" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationType",
                keyColumn: "Id",
                keyValue: new Guid("0e8ba1b4-0382-4a39-bb0d-2f654a1f1abc"));

            migrationBuilder.DeleteData(
                table: "RelationType",
                keyColumn: "Id",
                keyValue: new Guid("5e88157a-3ec0-4c04-9b86-041a07446f12"));
        }
    }
}

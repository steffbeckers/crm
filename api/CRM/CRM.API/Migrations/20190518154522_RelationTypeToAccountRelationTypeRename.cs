using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations
{
    public partial class RelationTypeToAccountRelationTypeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_RelationTypes_RelationTypeId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "RelationTypes");

            migrationBuilder.CreateTable(
                name: "AccountRelationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRelationTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccountRelationTypes",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { new Guid("0e8ba1b4-0382-4a39-bb0d-2f654a1f1abc"), "Customer", "customer" });

            migrationBuilder.InsertData(
                table: "AccountRelationTypes",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { new Guid("5e88157a-3ec0-4c04-9b86-041a07446f12"), "Partner", "partner" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountRelationTypes_RelationTypeId",
                table: "Accounts",
                column: "RelationTypeId",
                principalTable: "AccountRelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountRelationTypes_RelationTypeId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountRelationTypes");

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RelationTypes",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { new Guid("0e8ba1b4-0382-4a39-bb0d-2f654a1f1abc"), "Customer", "customer" });

            migrationBuilder.InsertData(
                table: "RelationTypes",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[] { new Guid("5e88157a-3ec0-4c04-9b86-041a07446f12"), "Partner", "partner" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_RelationTypes_RelationTypeId",
                table: "Accounts",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

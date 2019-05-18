using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.API.Migrations
{
    public partial class RemovedCascadeDeleteOfContactsForAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Accounts_AccountId",
                table: "Contact");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Accounts_AccountId",
                table: "Contact",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Accounts_AccountId",
                table: "Contact");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Accounts_AccountId",
                table: "Contact",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

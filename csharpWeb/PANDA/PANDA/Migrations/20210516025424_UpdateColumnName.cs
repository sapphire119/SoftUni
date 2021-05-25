using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Migrations
{
    public partial class UpdateColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_RecepientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_RecepientId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "RecepientId",
                table: "Receipts",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_RecepientId",
                table: "Receipts",
                newName: "IX_Receipts_RecipientId");

            migrationBuilder.RenameColumn(
                name: "RecepientId",
                table: "Packages",
                newName: "RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_RecepientId",
                table: "Packages",
                newName: "IX_Packages_RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_RecipientId",
                table: "Packages",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_RecipientId",
                table: "Receipts",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_RecipientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Users_RecipientId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Receipts",
                newName: "RecepientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_RecipientId",
                table: "Receipts",
                newName: "IX_Receipts_RecepientId");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "Packages",
                newName: "RecepientId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_RecipientId",
                table: "Packages",
                newName: "IX_Packages_RecepientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_RecepientId",
                table: "Packages",
                column: "RecepientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Users_RecepientId",
                table: "Receipts",
                column: "RecepientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

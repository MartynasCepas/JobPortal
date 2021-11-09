using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class offerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Offers_offerId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "offerId",
                table: "Applications",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_offerId",
                table: "Applications",
                newName: "IX_Applications_OfferId");

            migrationBuilder.AddColumn<int>(
                name: "offer_id",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Offers_OfferId",
                table: "Applications",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Offers_OfferId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "offer_id",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "Applications",
                newName: "offerId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_OfferId",
                table: "Applications",
                newName: "IX_Applications_offerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Offers_offerId",
                table: "Applications",
                column: "offerId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

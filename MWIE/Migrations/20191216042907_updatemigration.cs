using Microsoft.EntityFrameworkCore.Migrations;

namespace MWIE.Migrations
{
    public partial class updatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiptImportId",
                table: "DetailReceiptLiquidations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptImportId",
                table: "DetailReceiptLiquidations",
                nullable: true);
        }
    }
}

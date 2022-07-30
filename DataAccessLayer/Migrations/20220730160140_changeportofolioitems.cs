using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class changeportofolioitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortofolioItems_ServiceCategories_Service_Category_ID",
                table: "PortofolioItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PortofolioItems");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "PortofolioItems");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "PortofolioItems");

            migrationBuilder.RenameColumn(
                name: "Service_Category_ID",
                table: "PortofolioItems",
                newName: "Portfolio_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PortofolioItems_Service_Category_ID",
                table: "PortofolioItems",
                newName: "IX_PortofolioItems_Portfolio_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PortofolioItems_Portofolio_Portfolio_ID",
                table: "PortofolioItems",
                column: "Portfolio_ID",
                principalTable: "Portofolio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortofolioItems_Portofolio_Portfolio_ID",
                table: "PortofolioItems");

            migrationBuilder.RenameColumn(
                name: "Portfolio_ID",
                table: "PortofolioItems",
                newName: "Service_Category_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PortofolioItems_Portfolio_ID",
                table: "PortofolioItems",
                newName: "IX_PortofolioItems_Service_Category_ID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PortofolioItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "PortofolioItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "PortofolioItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PortofolioItems_ServiceCategories_Service_Category_ID",
                table: "PortofolioItems",
                column: "Service_Category_ID",
                principalTable: "ServiceCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

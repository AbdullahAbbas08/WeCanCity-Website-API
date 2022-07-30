using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class changeportofoliovideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortofolioVideo_Portofolio_Portofolio_ID",
                table: "PortofolioVideo");

            migrationBuilder.RenameColumn(
                name: "Portofolio_ID",
                table: "PortofolioVideo",
                newName: "Service_Category_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PortofolioVideo_Portofolio_ID",
                table: "PortofolioVideo",
                newName: "IX_PortofolioVideo_Service_Category_ID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PortofolioVideo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "PortofolioVideo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "PortofolioVideo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PortofolioVideo_ServiceCategories_Service_Category_ID",
                table: "PortofolioVideo",
                column: "Service_Category_ID",
                principalTable: "ServiceCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortofolioVideo_ServiceCategories_Service_Category_ID",
                table: "PortofolioVideo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PortofolioVideo");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "PortofolioVideo");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "PortofolioVideo");

            migrationBuilder.RenameColumn(
                name: "Service_Category_ID",
                table: "PortofolioVideo",
                newName: "Portofolio_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PortofolioVideo_Service_Category_ID",
                table: "PortofolioVideo",
                newName: "IX_PortofolioVideo_Portofolio_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PortofolioVideo_Portofolio_Portofolio_ID",
                table: "PortofolioVideo",
                column: "Portofolio_ID",
                principalTable: "Portofolio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

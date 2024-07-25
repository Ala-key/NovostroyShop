using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovostroyShop.Migrations
{
    public partial class AddManyImageProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc5",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageSrc3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageSrc4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageSrc5",
                table: "Products");
        }
    }
}

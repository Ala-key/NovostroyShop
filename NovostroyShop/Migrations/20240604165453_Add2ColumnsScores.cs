using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovostroyShop.Migrations
{
    public partial class Add2ColumnsScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "Products",
                newName: "Score");

            migrationBuilder.AddColumn<int>(
                name: "CountPersonScores",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountPersonScores",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Products",
                newName: "Stars");
        }
    }
}

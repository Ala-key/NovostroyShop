﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovostroyShop.Migrations
{
    public partial class AddColumnStars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Products");
        }
    }
}

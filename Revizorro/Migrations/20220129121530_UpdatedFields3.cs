using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revizorro.Migrations
{
    public partial class UpdatedFields3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Photos",
                table: "Places",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Places");
        }
    }
}

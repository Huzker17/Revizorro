using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revizorro.Migrations
{
    public partial class UpdatedFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "MainPhoto",
                table: "Places",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PlaceRating",
                table: "Places",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Authour",
                table: "FeedBacks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "FeedBacks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PathToPhoto = table.Column<string>(type: "text", nullable: true),
                    PlaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    MainPhoto = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "MainPhoto",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceRating",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Authour",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "FeedBacks");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });
        }
    }
}

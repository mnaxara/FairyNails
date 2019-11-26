using Microsoft.EntityFrameworkCore.Migrations;

namespace FairyNails.Service.Migrations
{
    public partial class Delete_PrixTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixTotal",
                table: "T_RENDEZ_VOUS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotal",
                table: "T_RENDEZ_VOUS",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

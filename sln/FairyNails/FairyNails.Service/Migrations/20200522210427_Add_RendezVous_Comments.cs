using Microsoft.EntityFrameworkCore.Migrations;

namespace FairyNails.Service.Migrations
{
    public partial class Add_RendezVous_Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comments",
                table: "T_RENDEZ_VOUS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comments",
                table: "T_RENDEZ_VOUS");
        }
    }
}

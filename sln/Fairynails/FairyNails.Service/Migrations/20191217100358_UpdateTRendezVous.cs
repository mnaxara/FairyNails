using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FairyNails.Service.Migrations
{
    public partial class UpdateTRendezVous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "DureeTotal",
                table: "T_RENDEZ_VOUS",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotal",
                table: "T_RENDEZ_VOUS",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DureeTotal",
                table: "T_RENDEZ_VOUS");

            migrationBuilder.DropColumn(
                name: "PrixTotal",
                table: "T_RENDEZ_VOUS");
        }
    }
}

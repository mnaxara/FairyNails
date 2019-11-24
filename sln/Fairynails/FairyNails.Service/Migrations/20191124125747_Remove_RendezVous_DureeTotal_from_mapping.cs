using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FairyNails.Service.Migrations
{
    public partial class Remove_RendezVous_DureeTotal_from_mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DureeTotal",
                table: "T_RENDEZ_VOUS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "DureeTotal",
                table: "T_RENDEZ_VOUS",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}

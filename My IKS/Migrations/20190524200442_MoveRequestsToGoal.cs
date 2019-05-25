using Microsoft.EntityFrameworkCore.Migrations;

namespace My_IKS.Migrations
{
    public partial class MoveRequestsToGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "RequestsAmount",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Requests",
                table: "Goals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requests",
                table: "Goals");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestsAmount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}

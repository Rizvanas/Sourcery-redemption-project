using Microsoft.EntityFrameworkCore.Migrations;

namespace My_IKS.Migrations
{
    public partial class UserSkillChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                table: "UserSkill",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "UserSkill");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Skills",
                nullable: false,
                defaultValue: 0);
        }
    }
}

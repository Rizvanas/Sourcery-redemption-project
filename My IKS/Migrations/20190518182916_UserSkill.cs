using Microsoft.EntityFrameworkCore.Migrations;

namespace My_IKS.Migrations
{
    public partial class UserSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Users_UserId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Goals",
                newName: "GoalId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Skills",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Goals",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Skills",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Skills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId",
                table: "Skills",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Users_UserId",
                table: "Skills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

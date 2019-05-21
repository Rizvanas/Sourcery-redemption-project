using Microsoft.EntityFrameworkCore.Migrations;

namespace My_IKS.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Goals",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Goals",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

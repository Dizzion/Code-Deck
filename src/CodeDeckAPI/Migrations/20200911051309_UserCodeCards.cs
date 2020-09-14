using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class UserCodeCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CodeCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodeCards_UserId",
                table: "CodeCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeCards_Users_UserId",
                table: "CodeCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeCards_Users_UserId",
                table: "CodeCards");

            migrationBuilder.DropIndex(
                name: "IX_CodeCards_UserId",
                table: "CodeCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CodeCards");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class swaponetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CodeCardCardId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CodeCardCardId",
                table: "Users",
                column: "CodeCardCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CodeCards_CodeCardCardId",
                table: "Users",
                column: "CodeCardCardId",
                principalTable: "CodeCards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CodeCards_CodeCardCardId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CodeCardCardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CodeCardCardId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CodeCards",
                type: "int",
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
    }
}

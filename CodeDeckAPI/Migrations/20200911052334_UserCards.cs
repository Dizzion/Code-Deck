using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class UserCards : Migration
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

            migrationBuilder.CreateTable(
                name: "UserCards",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CodeCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCards", x => new { x.CodeCardId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCards_CodeCards_CodeCardId",
                        column: x => x.CodeCardId,
                        principalTable: "CodeCards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_UserId",
                table: "UserCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCards");

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

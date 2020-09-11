using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class CodeChallengerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Answers_CodeChallengeId",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CodeChallengeId",
                table: "Answers",
                column: "CodeChallengeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Answers_CodeChallengeId",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CodeChallengeId",
                table: "Answers",
                column: "CodeChallengeId");
        }
    }
}

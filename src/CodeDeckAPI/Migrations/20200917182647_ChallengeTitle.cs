using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class ChallengeTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChallengeTitle",
                table: "CodeCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallengeTitle",
                table: "CodeCards");
        }
    }
}

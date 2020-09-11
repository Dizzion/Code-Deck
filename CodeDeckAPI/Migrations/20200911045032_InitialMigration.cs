using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeCards",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Challenge = table.Column<string>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    JavaAnswer = table.Column<string>(nullable: true),
                    JavaScriptAnswer = table.Column<string>(nullable: true),
                    PythonAnswer = table.Column<string>(nullable: true),
                    CAnswers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeCards", x => x.CardId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeCards");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeDeckAPI.Migrations
{
    public partial class PythonAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PythonAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerCode = table.Column<string>(nullable: true),
                    AnswersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PythonAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PythonAnswers_Answers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PythonAnswers_AnswersId",
                table: "PythonAnswers",
                column: "AnswersId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PythonAnswers");
        }
    }
}

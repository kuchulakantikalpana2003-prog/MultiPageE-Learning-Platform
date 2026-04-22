using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPage_ELearning_Platform1.Migrations
{
    /// <inheritdoc />
    public partial class AddResultFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Quizzes_QuizId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_QuizId",
                table: "Results");

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "Results",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Results");

            migrationBuilder.CreateIndex(
                name: "IX_Results_QuizId",
                table: "Results",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Quizzes_QuizId",
                table: "Results",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

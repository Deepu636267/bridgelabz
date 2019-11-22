using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collaborators_Notes_NotesModelsId",
                table: "collaborators");

            migrationBuilder.DropIndex(
                name: "IX_collaborators_NotesModelsId",
                table: "collaborators");

            migrationBuilder.DropColumn(
                name: "NotesModelsId",
                table: "collaborators");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotesModelsId",
                table: "collaborators",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_NotesModelsId",
                table: "collaborators",
                column: "NotesModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_collaborators_Notes_NotesModelsId",
                table: "collaborators",
                column: "NotesModelsId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

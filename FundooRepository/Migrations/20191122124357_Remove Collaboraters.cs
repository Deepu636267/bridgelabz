using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class RemoveCollaboraters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_collaborators_CollaboratorsId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CollaboratorsId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CollaboratorsId",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollaboratorsId",
                table: "Notes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CollaboratorsId",
                table: "Notes",
                column: "CollaboratorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_collaborators_CollaboratorsId",
                table: "Notes",
                column: "CollaboratorsId",
                principalTable: "collaborators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

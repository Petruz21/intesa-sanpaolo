using Microsoft.EntityFrameworkCore.Migrations;

namespace sanpaolo.Migrations
{
    public partial class Conti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transazioni_Conti_ContoId",
                table: "Transazioni");

            migrationBuilder.DropIndex(
                name: "IX_Transazioni_ContoId",
                table: "Transazioni");

            migrationBuilder.DropColumn(
                name: "ContoId",
                table: "Transazioni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContoId",
                table: "Transazioni",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transazioni_ContoId",
                table: "Transazioni",
                column: "ContoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transazioni_Conti_ContoId",
                table: "Transazioni",
                column: "ContoId",
                principalTable: "Conti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

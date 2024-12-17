using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaApi.Migrations
{
    public partial class CriarChaveEstrangeiraEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendas_EnderecoId",
                table: "Agendas");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_EnderecoId",
                table: "Agendas",
                column: "EnderecoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendas_EnderecoId",
                table: "Agendas");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_EnderecoId",
                table: "Agendas",
                column: "EnderecoId");
        }
    }
}

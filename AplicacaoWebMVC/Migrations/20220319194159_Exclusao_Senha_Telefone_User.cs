using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacaoWebMVC.Migrations
{
    public partial class Exclusao_Senha_Telefone_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Autores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

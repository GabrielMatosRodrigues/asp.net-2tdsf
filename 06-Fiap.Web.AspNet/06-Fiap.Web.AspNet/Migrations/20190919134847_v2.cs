using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _06_Fiap.Web.AspNet.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SindicoId",
                table: "TblCondominio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Construtoras",
                columns: table => new
                {
                    ConstrutoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Construtoras", x => x.ConstrutoraId);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    ImovelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    AreaUtil = table.Column<float>(nullable: false),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.ImovelId);
                    table.ForeignKey(
                        name: "FK_Imoveis_TblCondominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "TblCondominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sindicos",
                columns: table => new
                {
                    SindicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sindicos", x => x.SindicoId);
                });

            migrationBuilder.CreateTable(
                name: "CondominioConstrutora",
                columns: table => new
                {
                    ConstrutoraId = table.Column<int>(nullable: false),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominioConstrutora", x => new { x.ConstrutoraId, x.CondominioId });
                    table.ForeignKey(
                        name: "FK_CondominioConstrutora_TblCondominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "TblCondominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondominioConstrutora_Construtoras_ConstrutoraId",
                        column: x => x.ConstrutoraId,
                        principalTable: "Construtoras",
                        principalColumn: "ConstrutoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCondominio_SindicoId",
                table: "TblCondominio",
                column: "SindicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondominioConstrutora_CondominioId",
                table: "CondominioConstrutora",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CondominioId",
                table: "Imoveis",
                column: "CondominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCondominio_Sindicos_SindicoId",
                table: "TblCondominio",
                column: "SindicoId",
                principalTable: "Sindicos",
                principalColumn: "SindicoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCondominio_Sindicos_SindicoId",
                table: "TblCondominio");

            migrationBuilder.DropTable(
                name: "CondominioConstrutora");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Sindicos");

            migrationBuilder.DropTable(
                name: "Construtoras");

            migrationBuilder.DropIndex(
                name: "IX_TblCondominio_SindicoId",
                table: "TblCondominio");

            migrationBuilder.DropColumn(
                name: "SindicoId",
                table: "TblCondominio");
        }
    }
}

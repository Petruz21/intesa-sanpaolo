using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sanpaolo.Migrations
{
    public partial class Utenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Sede = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salvadanaio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoAttuale = table.Column<float>(nullable: false),
                    Info = table.Column<string>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    DataScadenza = table.Column<DateTime>(nullable: false),
                    AmmontareObbiettivo = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salvadanaio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataDiNascita = table.Column<DateTime>(nullable: false),
                    CodiceFiscale = table.Column<string>(nullable: true),
                    NumeroCartaIdentita = table.Column<string>(nullable: true),
                    Nazionalita = table.Column<string>(nullable: true),
                    Paese = table.Column<string>(nullable: true),
                    Regione = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    Comune = table.Column<string>(nullable: true),
                    Cap = table.Column<string>(nullable: true),
                    Via = table.Column<string>(nullable: true),
                    Ruolo = table.Column<int>(nullable: false),
                    BancaId = table.Column<int>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utenti_Banca_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Banca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iban = table.Column<string>(nullable: true),
                    NConto = table.Column<int>(nullable: false),
                    Saldo = table.Column<float>(nullable: false),
                    UtenteId = table.Column<int>(nullable: false),
                    SalvadanaioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conti_Salvadanaio_SalvadanaioId",
                        column: x => x.SalvadanaioId,
                        principalTable: "Salvadanaio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conti_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conti_SalvadanaioId",
                table: "Conti",
                column: "SalvadanaioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conti_UtenteId",
                table: "Conti",
                column: "UtenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_BancaId",
                table: "Utenti",
                column: "BancaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conti");

            migrationBuilder.DropTable(
                name: "Salvadanaio");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Banca");
        }
    }
}

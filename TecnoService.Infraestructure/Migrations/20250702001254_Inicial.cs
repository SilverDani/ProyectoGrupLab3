using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnoService.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IDMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IDMarca);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IDPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IDPersona);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    IDDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMarca = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.IDDispositivo);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Marcas_IDMarca",
                        column: x => x.IDMarca,
                        principalTable: "Marcas",
                        principalColumn: "IDMarca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPersona = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IDCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_IDPersona",
                        column: x => x.IDPersona,
                        principalTable: "Personas",
                        principalColumn: "IDPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    IDTrabajador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPersona = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.IDTrabajador);
                    table.ForeignKey(
                        name: "FK_Trabajadores_Personas_IDPersona",
                        column: x => x.IDPersona,
                        principalTable: "Personas",
                        principalColumn: "IDPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    IDInDis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDispositivo = table.Column<int>(type: "int", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.IDInDis);
                    table.ForeignKey(
                        name: "FK_Ingreso_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingreso_Dispositivos_IDDispositivo",
                        column: x => x.IDDispositivo,
                        principalTable: "Dispositivos",
                        principalColumn: "IDDispositivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IDFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDInDis = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetalleArreglo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRetiro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDTrabajador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IDFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Ingreso_IDInDis",
                        column: x => x.IDInDis,
                        principalTable: "Ingreso",
                        principalColumn: "IDInDis",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_Trabajadores_IDTrabajador",
                        column: x => x.IDTrabajador,
                        principalTable: "Trabajadores",
                        principalColumn: "IDTrabajador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IDPersona",
                table: "Clientes",
                column: "IDPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_IDMarca",
                table: "Dispositivos",
                column: "IDMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IDInDis",
                table: "Facturas",
                column: "IDInDis",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IDTrabajador",
                table: "Facturas",
                column: "IDTrabajador");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_IDCliente",
                table: "Ingreso",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_IDDispositivo",
                table: "Ingreso",
                column: "IDDispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_IDPersona",
                table: "Trabajadores",
                column: "IDPersona",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pablo_Burgos_Proyecto_Final.Migrations
{
    public partial class migracion_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    FechaDeCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CantidadProductos = table.Column<int>(type: "INTEGER", nullable: false),
                    SuplidoresId = table.Column<int>(type: "INTEGER", nullable: false),
                    precioTotal = table.Column<float>(type: "REAL", nullable: false),
                    DescripcionSuplidor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                });

            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    DispositivoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    SistemaOperativo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.DispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    Itbis = table.Column<float>(type: "REAL", nullable: false),
                    PrecioConItbis = table.Column<float>(type: "REAL", nullable: false),
                    PrecioTotal = table.Column<float>(type: "REAL", nullable: false),
                    DispositivoId = table.Column<int>(type: "INTEGER", nullable: false),
                    descripcionDispositivo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidoresId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Representante = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Compania = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidoresId);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalles",
                columns: table => new
                {
                    ComprasDetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioUnidad = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalles", x => x.ComprasDetallesId);
                    table.ForeignKey(
                        name: "FK_ComprasDetalles_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dispositivos",
                columns: new[] { "DispositivoId", "Marca", "Modelo", "SistemaOperativo" },
                values: new object[] { 1, "ZTE", "546Z", "Android" });

            migrationBuilder.InsertData(
                table: "Dispositivos",
                columns: new[] { "DispositivoId", "Marca", "Modelo", "SistemaOperativo" },
                values: new object[] { 2, "Iphone", "X", "IOS" });

            migrationBuilder.InsertData(
                table: "Dispositivos",
                columns: new[] { "DispositivoId", "Marca", "Modelo", "SistemaOperativo" },
                values: new object[] { 3, "Alcatel", "Lite", "Android" });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_CompraId",
                table: "ComprasDetalles",
                column: "CompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasDetalles");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}

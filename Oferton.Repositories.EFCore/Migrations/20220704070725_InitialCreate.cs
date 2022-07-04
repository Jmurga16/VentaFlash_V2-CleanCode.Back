using Microsoft.EntityFrameworkCore.Migrations;

namespace Oferton.Repositories.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    nIdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sCorreo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.nIdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    nIdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sNombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nCalificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nStock = table.Column<int>(type: "int", nullable: false),
                    sRutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.nIdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    nIdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nIdProducto = table.Column<int>(type: "int", nullable: false),
                    nIdCliente = table.Column<int>(type: "int", nullable: false),
                    bEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.nIdOrden);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_nIdCliente",
                        column: x => x.nIdCliente,
                        principalTable: "Customers",
                        principalColumn: "nIdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_nIdProducto",
                        column: x => x.nIdProducto,
                        principalTable: "Products",
                        principalColumn: "nIdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "nIdProducto", "nCalificacion", "nPrecio", "nStock", "sDescripcion", "sNombreProducto", "sRutaImagen" },
                values: new object[] { 1, 8m, 430m, 5, "Marca: JBL;Modelo: TUNE 750BTNC;Tipo: Audifonos Bluetooth; Peso: 220gr.;Resistente al agua: No", "AUDIFONOS SKULLCANDY", "assets/images/items/9.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_nIdCliente",
                table: "Orders",
                column: "nIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_nIdProducto",
                table: "Orders",
                column: "nIdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

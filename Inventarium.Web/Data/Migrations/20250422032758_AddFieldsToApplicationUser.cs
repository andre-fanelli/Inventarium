using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventariumWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cadImpressora",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidade = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Depto = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Patrimonio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadImpre__3214EC27DE0EE400", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadMonitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidade = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Depto = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    NS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Patrimonio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadMonit__3214EC275A5D2762", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadNote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidade = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Depto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Processador = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Hostname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Patrimonio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadNote__3214EC27763EFAE7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadPC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidade = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Depto = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Processador = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Hostname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    NS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Patrimonio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadPC__3214EC2720EDD71D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadRede",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidade = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Depto = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Patrimonio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadRede__3214EC27DBEC07A6", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cadTablet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidade = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Depto = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    NS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Patrimonio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cadTable__3214EC27DA06A619", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadImpressora");

            migrationBuilder.DropTable(
                name: "cadMonitor");

            migrationBuilder.DropTable(
                name: "cadNote");

            migrationBuilder.DropTable(
                name: "cadPC");

            migrationBuilder.DropTable(
                name: "cadRede");

            migrationBuilder.DropTable(
                name: "cadTablet");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");
        }
    }
}

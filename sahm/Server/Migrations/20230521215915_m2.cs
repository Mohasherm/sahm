using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sahm.Server.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CenterAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Center_Id = table.Column<int>(type: "int", nullable: true),
                    Asset_Id = table.Column<int>(type: "int", nullable: true),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterAssets_Assets_Asset_Id",
                        column: x => x.Asset_Id,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CenterAssets_Centers_Center_Id",
                        column: x => x.Center_Id,
                        principalTable: "Centers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TankOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tank_Id = table.Column<int>(type: "int", nullable: true),
                    InQTY = table.Column<double>(type: "float", nullable: false),
                    OutQTY = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Center_Id = table.Column<int>(type: "int", nullable: true),
                    QTY = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CenterAssets_Asset_Id",
                table: "CenterAssets",
                column: "Asset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CenterAssets_Center_Id",
                table: "CenterAssets",
                column: "Center_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterAssets");

            migrationBuilder.DropTable(
                name: "TankOperations");

            migrationBuilder.DropTable(
                name: "Tanks");
        }
    }
}

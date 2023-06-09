using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sahm.Server.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Msessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_Center_Id",
                table: "Tanks",
                column: "Center_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TankOperations_Tank_Id",
                table: "TankOperations",
                column: "Tank_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_User_Id",
                table: "Notifications",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TankOperations_Tanks_Tank_Id",
                table: "TankOperations",
                column: "Tank_Id",
                principalTable: "Tanks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Centers_Center_Id",
                table: "Tanks",
                column: "Center_Id",
                principalTable: "Centers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TankOperations_Tanks_Tank_Id",
                table: "TankOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Centers_Center_Id",
                table: "Tanks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_Center_Id",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_TankOperations_Tank_Id",
                table: "TankOperations");
        }
    }
}

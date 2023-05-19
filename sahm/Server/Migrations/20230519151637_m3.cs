using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sahm.Server.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("15a7bc60-0484-44ad-bb4c-4f4c2e08a666"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d6e46ed-721c-4e8e-b5c2-c395a706164d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a1e3819-cb2d-4a25-afc8-893d9c812012"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6f558ba8-cbf3-447e-acaf-45e57ce37622"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98cd36d1-8418-4314-a19c-1d3a94bdd8a8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dacaf0eb-4248-495e-87fe-7efec0f4b224"));

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3bef1ed3-312e-433b-bd2c-54f76002b7c8"), "b646f66d-d9c4-4b18-8577-c0a71d65d084", "User", null },
                    { new Guid("4746e259-6077-4ab7-a663-5c5213a429aa"), "e26879e3-00dd-4195-9b7a-f52fcf903c7d", "BuyAdmin", null },
                    { new Guid("9cc3b430-31dc-4dc6-948e-3546d4dda5b3"), "3bc7f9ce-51e2-46c7-a40f-e78fd4540d9f", "SuperVisor", null },
                    { new Guid("bb68b06a-172d-4a01-b412-bbf7d24da449"), "07027283-fe3d-43e4-aef3-de3237bdc4a9", "QulityAdmin", null },
                    { new Guid("f601ce37-8b0d-4a22-9b7c-6ed83e092c5f"), "f873da71-3598-410d-88ca-d41014b4a38c", "SuperAdmin", null },
                    { new Guid("fee31fd9-215f-48cc-8340-ab7d3df4468d"), "384757cc-30a4-43e4-a8dd-4bf3106ea3ab", "MaintenanceAdmin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3bef1ed3-312e-433b-bd2c-54f76002b7c8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4746e259-6077-4ab7-a663-5c5213a429aa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9cc3b430-31dc-4dc6-948e-3546d4dda5b3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb68b06a-172d-4a01-b412-bbf7d24da449"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f601ce37-8b0d-4a22-9b7c-6ed83e092c5f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fee31fd9-215f-48cc-8340-ab7d3df4468d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("15a7bc60-0484-44ad-bb4c-4f4c2e08a666"), "68aa19a1-a56c-4fac-907c-3df6596266b2", "BuyAdmin", null },
                    { new Guid("3d6e46ed-721c-4e8e-b5c2-c395a706164d"), "2a818886-09cb-4167-8385-0663068f3136", "SuperAdmin", null },
                    { new Guid("4a1e3819-cb2d-4a25-afc8-893d9c812012"), "5d2c3bf2-2565-40a0-9177-dbd0bd5dd111", "QulityAdmin", null },
                    { new Guid("6f558ba8-cbf3-447e-acaf-45e57ce37622"), "db9f5885-6ef7-4514-8c0c-9413b3e5aa3b", "User", null },
                    { new Guid("98cd36d1-8418-4314-a19c-1d3a94bdd8a8"), "5bb79097-bfef-41eb-bef2-7e35108a8677", "MaintenanceAdmin", null },
                    { new Guid("dacaf0eb-4248-495e-87fe-7efec0f4b224"), "a55e4a9b-6496-406b-b699-05a50fcb609c", "SuperVisor", null }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sahm.Server.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17669d3a-212b-4dbc-8240-8417ba41813b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e13d3aa-c33e-4da1-88ce-ec1b8498f179"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cc4c823-7812-4f85-a1d5-6b6126c9a506"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a0451fd-6770-4246-915b-d30f3d5702d2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e1f2728-3b2e-42ce-87f8-79809158c89a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e841b3f1-70cf-46bd-955b-3fdf26b7503e"));

            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centers_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Centers_User_Id",
                table: "Centers",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Centers");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("17669d3a-212b-4dbc-8240-8417ba41813b"), "c4c7099c-f333-4790-b678-8537d36fbc27", "BuyAdmin", null },
                    { new Guid("2e13d3aa-c33e-4da1-88ce-ec1b8498f179"), "938b0365-8fba-4211-a14b-0205efb8f9f9", "MaintenanceAdmin", null },
                    { new Guid("4cc4c823-7812-4f85-a1d5-6b6126c9a506"), "1f5b0436-84b6-42d7-a67d-492c6bc15502", "SuperVisor", null },
                    { new Guid("5a0451fd-6770-4246-915b-d30f3d5702d2"), "3eb605fb-4632-4e17-b686-cae5b4a3b07d", "SuperAdmin", null },
                    { new Guid("7e1f2728-3b2e-42ce-87f8-79809158c89a"), "6a57e4b8-6141-461b-be3e-63c501018987", "QulityAdmin", null },
                    { new Guid("e841b3f1-70cf-46bd-955b-3fdf26b7503e"), "73716f08-d20f-44d4-ac9e-124d2c9728f4", "User", null }
                });
        }
    }
}

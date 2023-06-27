using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class AddApartamentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartaments_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartaments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "2a9b66dd-78d1-407c-a251-29c13ed4e8f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "76d6a7f7-4ab9-43e4-b9a9-4a459caf79ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf7095f-f42b-4018-8421-8579c1cd11d1", "AQAAAAEAACcQAAAAEEtBJv3pJETjYwyNu43bnULp511SrVUZQ47LKIGWTIKvoFDU3snhFrwkoGaTWfVqsw==", "4a95322e-e0da-43cc-b979-5ca3f0c0f13b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "683da073-c6bc-4dec-b835-c278af143e5d", "AQAAAAEAACcQAAAAEPIDAOVmvVV/pC462V7fxUrbDSHYAkKCQqhh6ZPdEMzR54RbpPOwWdv8WJJjRlZwUw==", "99a3c19d-61b6-4143-89de-71e353b30ae4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fea088a-ec1a-4313-b3cd-ff5b835098c0", "AQAAAAEAACcQAAAAEJBcMq9w4qsRhdjFtmO3OQamo/SUAICuufehxklIl963Pt4EarrFpEtZF6sGtsED9A==", "12c44423-36c6-4854-a85f-301506ea4a6b" });

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_AddressId",
                table: "Apartaments",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_OwnerId",
                table: "Apartaments",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartaments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "281002f3-1aab-4a88-b803-cefbf8e8615b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "1f557737-98c4-465c-87f7-43911bafb6a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd4cc5be-dc74-478c-afac-7319445b1a0f", "AQAAAAEAACcQAAAAEDGNIrLN+D7cII45sSdCOqw1O0Rogas9YjpLA+dDegLDyIzQhpbLI2Yl4T6kzwFaJA==", "decedab5-1877-49d1-b097-d1c9fb13256a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fed4592-666c-46dd-8970-20f7942a2be1", "AQAAAAEAACcQAAAAEKJbb/GoS8BadK/gcxGqMynrn7LQGtiz1Oq6KdjuatvRuYNSJmWQ0dl3fc3XIhJCtA==", "ee18a46d-b019-43e7-8076-a26ab7329eff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dc5b0cd-9810-40dc-b808-a5a730591169", "AQAAAAEAACcQAAAAEI/oWKp+a4qz/B2VbWxMq1dO/6hu7sKzhhco/fRQRXMs9f0d/uAs5nrjLhzBcL+w5g==", "d7401f97-ea2d-45a8-9dc7-14fcea6bac98" });
        }
    }
}

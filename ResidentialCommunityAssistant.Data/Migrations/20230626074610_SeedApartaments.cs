using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class SeedApartaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartaments_Addresses_AddressId",
                table: "Apartaments");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Apartaments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Apartaments",
                columns: new[] { "Id", "AddressId", "Number", "OwnerId", "Signature" },
                values: new object[,]
                {
                    { 1, 2, 1, "8815d5cc-c403-43e8-b2d3-40f57a8d1d61", "A" },
                    { 2, 2, 2, "579b52e0-38e4-4f41-a30f-31e72767c536", "A" },
                    { 3, 2, 3, "88d33982-06d8-43f0-b809-7d6ed7f3ab23", "A" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "ee5bd14b-63ce-4061-8a32-b94eeced0ddb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "79a4d88e-2dd9-4d8a-9bc1-0de064693073");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c1f85dc-f981-4b5a-bf8d-de19fe067a03", "AQAAAAEAACcQAAAAEGihF2+kTvuj+4v1dbzkj0wC/ZVNEYQphP4msa1j1P8nd5c3m6kAGYzCesMZ+7kILw==", "5d83bade-c8fc-48aa-aa23-76883d3c76cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f304765-9e3f-4c1d-97b0-0723988e1067", "AQAAAAEAACcQAAAAEFk490UqozmA2yT7vnNwo+DE90OrxOBtX3dfH8VJkXIvcQvlP+z9/C9jKHMXC+LW4Q==", "61d7ae22-e3e7-41e6-8945-b1c0a121d57d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c58d58c5-ba1f-408e-8f2b-5d8c898810f1", "AQAAAAEAACcQAAAAEKhlt2RHyudu7j5h8yogE+SmpfBV3zj8gfYIANeA1eDd29A7Gu846y2hxM0YZdtUEg==", "c52b1c94-463e-4446-980e-ea41231480c8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartaments_Addresses_AddressId",
                table: "Apartaments",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartaments_Addresses_AddressId",
                table: "Apartaments");

            migrationBuilder.DeleteData(
                table: "Apartaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Apartaments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Apartaments_Addresses_AddressId",
                table: "Apartaments",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}

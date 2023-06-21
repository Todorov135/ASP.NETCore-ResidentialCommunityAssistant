using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class AddCommunityTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityTopics_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityTopics_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "CommunityTopics",
                columns: new[] { "Id", "AddressId", "CreatedOn", "CreatorId", "Description", "Title" },
                values: new object[] { 1, 2, new DateTime(2023, 6, 21, 15, 5, 15, 0, DateTimeKind.Unspecified), "579b52e0-38e4-4f41-a30f-31e72767c536", "Закупуване, засаждане и подръжка на тревни чимове за двора пред сградата.", "Озеленяване на градинка" });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTopics_AddressId",
                table: "CommunityTopics",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityTopics_CreatorId",
                table: "CommunityTopics",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityTopics");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "487d6561-6536-4fb8-8ec3-6c57f072a00d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "471a83b7-4501-4e26-8d20-e043e6aa7923");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "226be5a7-d9e7-4379-ad6d-455c5c6f5d78", "AQAAAAEAACcQAAAAEEcZqoJcdTWR9/f8L1xRdT2HiImq7IAXLtkGzoWd1sv5XdJ4fLyeG6M7GLP6cL7kcw==", "8455053f-5f9c-42f9-81a6-4f81cc2af51c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80bea816-cc57-4cb3-93aa-cf73d7823b97", "AQAAAAEAACcQAAAAEEM2ALQZzUw2d83SJN2gVtn8Esm2SLcHqsm7E224RE20Td8LdOIxRoCzKcUn2AUKrw==", "88f694fb-0974-4f71-964d-9d88926eef5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b27101c8-3c4a-44e9-84b2-d67c474c371c", "AQAAAAEAACcQAAAAENRk9ItI2aJKLRQCSsTuY+U7ii5G4UNiVy/IJinrTG5/NQeF7DA4r4D3fpAOrC/cEQ==", "4ed41f77-c2f3-4ccf-b7fe-f03b69808e8b" });
        }
    }
}

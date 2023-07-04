using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class AddHomeManagersApprovalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeManagersApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeManagerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApartamentId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeManagersApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeManagersApprovals_Apartaments_ApartamentId",
                        column: x => x.ApartamentId,
                        principalTable: "Apartaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeManagersApprovals_AspNetUsers_HomeManagerId",
                        column: x => x.HomeManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "f6f692ac-601c-4809-b18d-5e3b007b7f86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "641e7da8-bedb-4a27-9ef5-02588891ae56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daf1cae5-b92c-4f9e-82a5-bc494d35a41f", "AQAAAAEAACcQAAAAEHu73TsXKZ10M/ToTzAMHc3ljtE4vhktm2tulLOWp4gfKWMFiYIcqvRv4WTgUbIOow==", "5ee3ae72-96ff-4892-81ef-0f3a92ae856f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c42d1603-c0e1-4a50-99ef-4f003bb872d1", "AQAAAAEAACcQAAAAEFvFG0EkEYBraID5wxOYyy8JPzs5m845AnVOkJM9MBoXZ30lS8iONeWFxS2k9zI+UQ==", "9a30604e-ccbb-4052-b50a-57548c24a3fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a803fb36-06dd-4f68-b2af-30f9b2a47b65", "AQAAAAEAACcQAAAAEMC8sf9AmOU0qEq6cHCp+qcNWuhIpW2vrsgUVADX5wwb7URYChnDQC2oqEEckbgM6A==", "a817c3f5-7936-4872-8563-bfb53781895d" });

            migrationBuilder.CreateIndex(
                name: "IX_HomeManagersApprovals_ApartamentId",
                table: "HomeManagersApprovals",
                column: "ApartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeManagersApprovals_HomeManagerId",
                table: "HomeManagersApprovals",
                column: "HomeManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeManagersApprovals");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "f1804c0c-48f0-4be3-a4d4-f83238096e1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "5180aae7-41da-4e1c-b4d3-9a4688959f28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "287ca5c2-c271-4393-9e4e-42076f7c6c50", "AQAAAAEAACcQAAAAEIZNkws+NOPz+ouElamK68Ua8GUtxixi0EMU2WOKtlgRSpKrbFAKDbYH7BUI64Cfgg==", "510519dd-c5e8-41b5-95e0-044780d1c4a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ba02d36-fc98-40c4-9aee-a6433b8d7c00", "AQAAAAEAACcQAAAAEAg0l0aXG1BsINmWrU4ZC1PEDdVQtTSqUOJBvWDYX4N2purcT5RdiVG5o4UPgulOvA==", "e4353205-968c-4547-851d-2b368634813a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9b9336d-6e72-42c6-baf2-c2e214b1a403", "AQAAAAEAACcQAAAAEP8bbSelJgChWun1tVL69OiTDP6xxWSXr3aPME+a6f1WpLqa6d8ETH1hjegKqJDewA==", "603d5b96-e12a-490a-b187-8313e7471317" });
        }
    }
}

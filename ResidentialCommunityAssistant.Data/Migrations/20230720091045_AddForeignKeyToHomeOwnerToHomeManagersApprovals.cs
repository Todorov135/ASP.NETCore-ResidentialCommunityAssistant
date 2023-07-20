using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class AddForeignKeyToHomeOwnerToHomeManagersApprovals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HomeOwnerId",
                table: "HomeManagersApprovals",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "6fea8b42-b8b9-46d6-a244-43e21df83c86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "acf9e114-f674-4363-a82b-4802385301fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbacb3dd-2225-4c79-86b5-1edae51c4d17", "AQAAAAEAACcQAAAAEHEMecWzts2+xRtsfGA+VcZVzHlCFKDd/ZiS3wn79611xYsx7eNY5EusFhrDUjKidA==", "23e08ba4-5157-48b0-bc5e-6ca3f131da6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ab6adcd-56fe-4aa2-9272-f3926f091352", "AQAAAAEAACcQAAAAELYGwSwMrQZu3EGbsl16HvENh1JXHbRyZKE+182+W+tD1ylNP2U5KCH/iNyf403XhA==", "12f99614-a749-4d75-abd3-a83e67eb6078" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6872d834-ce41-4f6f-8dae-38ed8fc1205d", "AQAAAAEAACcQAAAAEN6b/niX1AR746mST0lH0IuDXqzDbMWlIWu1Usb0pRbDaZYT40RnNgHCLbPDLji07A==", "be24abce-aafb-400e-8f6b-f64fc753b347" });

            migrationBuilder.CreateIndex(
                name: "IX_HomeManagersApprovals_HomeOwnerId",
                table: "HomeManagersApprovals",
                column: "HomeOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeManagersApprovals_AspNetUsers_HomeOwnerId",
                table: "HomeManagersApprovals",
                column: "HomeOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeManagersApprovals_AspNetUsers_HomeOwnerId",
                table: "HomeManagersApprovals");

            migrationBuilder.DropIndex(
                name: "IX_HomeManagersApprovals_HomeOwnerId",
                table: "HomeManagersApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "HomeOwnerId",
                table: "HomeManagersApprovals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "040e885f-b26a-4f7b-b3ac-e927e62e5b2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "a674794d-c3d4-426d-94b8-88a92960247a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3f1ecd2-20c7-483f-a2d9-e634ceabf125", "AQAAAAEAACcQAAAAEC0W0eTWSp+TGfmF5MU4dsUmL8SQ/pf+rvcoU34P58uYghcuBlXr9KPJL7UGR1AiOg==", "e019ee2a-75c5-46f0-bb18-a541b3e0a66a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0cb6615-0842-4ef8-ad15-a14237b75d8d", "AQAAAAEAACcQAAAAENeD2BZ6Jm2+b6glL96xpbXG9fSoP1vdoH+sKuhdyyvmMBTgPftBwNj+yKlhKINStw==", "f7598960-82cd-41f3-833e-543a59f66425" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00cb886a-4d96-451c-aa06-837722ec34bc", "AQAAAAEAACcQAAAAEKboYJrW5eyr3yk80NfiPpU1eWfn2aH6w700Vnjbjgt5q/Lv1jsvAaFyj22Z0ekLiA==", "e4601680-79b6-464c-959e-9cae1cffec60" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class RemoveConstraintFromHomeManagerApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeManagersApprovals_AspNetUsers_HomeOwnerId",
                table: "HomeManagersApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "HomeOwnerId",
                table: "HomeManagersApprovals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "530e4e3a-de94-4377-8dc4-99c7869a8201");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "7ca600e7-ad6b-4495-a0d0-27a1264203eb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f8410ba-6aad-46e2-81ee-4eacf385e87c", "AQAAAAEAACcQAAAAEO7aN2++OzYozWg0Kr/ZVcCfsbnjEjq7fzDu972xNWED8tJ8YB7TplwcrLeS95DpCw==", "7ead310b-1c4e-492c-9746-9dea124ed143" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adeebfda-b4f0-43ab-a723-ed439a33e7d7", "AQAAAAEAACcQAAAAEDmUJsh6EjXdT4E5hpUEYiO9waL7/QQIPjMWCBGeMHz8dJbeTrsmIuaefAlv/4ZWWQ==", "c8509fad-0c30-4d28-b3ef-c19f772f5850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8a92683-6ee3-4354-ac55-ce47b3bea2b9", "AQAAAAEAACcQAAAAEFFgZWBfglmb/yB7aXIAWsX70oAIX9XaGDPLW3NDafCY8tI4XzGAL8FpIa8p9Gi3vw==", "7dd0ba58-ddbd-4b1d-b3ab-b6f50e61be37" });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeManagersApprovals_AspNetUsers_HomeOwnerId",
                table: "HomeManagersApprovals",
                column: "HomeOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeManagersApprovals_AspNetUsers_HomeOwnerId",
                table: "HomeManagersApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "HomeOwnerId",
                table: "HomeManagersApprovals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_HomeManagersApprovals_AspNetUsers_HomeOwnerId",
                table: "HomeManagersApprovals",
                column: "HomeOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

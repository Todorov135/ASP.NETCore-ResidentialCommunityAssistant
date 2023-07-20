using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class RemoveAllConstraintFromHomeManagerApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "HomeManagersApprovals");

            migrationBuilder.AlterColumn<string>(
                name: "HomeManagerId",
                table: "HomeManagersApprovals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "620d549e-1169-4bad-bbc4-fcb1374e7f65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "85c4e6f9-a86d-420e-bfb1-94f1b1a03e70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49204d9f-d280-4da3-bb49-0d6f61ff4245", "AQAAAAEAACcQAAAAEH3uISK72x3PfvvJh4j8YpGDIi3LoY/KAYc6E3L6O0fK0CfXoypgrlfSdIwF+wMHAA==", "72207651-fe6c-40de-b569-396cf66f297c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1799263-ae4e-4d79-8d93-dc923c97bb02", "AQAAAAEAACcQAAAAEHb1AS+iSpe3fy+RDBXgGmhQHIFIpVuUUFGipckusC0hd9BQ3UhX1uw2loUJ7D2juw==", "d4454aa1-fcad-489b-87cc-d480cd3549b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ce7521c-8c5b-4d93-93f7-e260a08585e4", "AQAAAAEAACcQAAAAEH4mtbOgpWRS77Y7bBoYQR+onxtPb4/AaAGbVzqWtiUA508rugrQ3L8sibZpomodfw==", "9adde18d-9b07-49e6-8527-3beeda142b25" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HomeManagerId",
                table: "HomeManagersApprovals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "HomeManagersApprovals",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }
    }
}

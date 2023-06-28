using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class ExtendedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "287ca5c2-c271-4393-9e4e-42076f7c6c50", "Иван", "Иванов", "AQAAAAEAACcQAAAAEIZNkws+NOPz+ouElamK68Ua8GUtxixi0EMU2WOKtlgRSpKrbFAKDbYH7BUI64Cfgg==", "510519dd-c5e8-41b5-95e0-044780d1c4a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ba02d36-fc98-40c4-9aee-a6433b8d7c00", "Тодор", "Тодоров", "AQAAAAEAACcQAAAAEAg0l0aXG1BsINmWrU4ZC1PEDdVQtTSqUOJBvWDYX4N2purcT5RdiVG5o4UPgulOvA==", "e4353205-968c-4547-851d-2b368634813a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9b9336d-6e72-42c6-baf2-c2e214b1a403", "Петър", "Петров", "AQAAAAEAACcQAAAAEP8bbSelJgChWun1tVL69OiTDP6xxWSXr3aPME+a6f1WpLqa6d8ETH1hjegKqJDewA==", "603d5b96-e12a-490a-b187-8313e7471317" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "aab3dbc7-a2c6-4220-9651-4c2ea662b9b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "74b0aa59-6659-4bf0-8298-420832a196e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91925cc1-4625-4567-a9b5-88a435a89ba6", "AQAAAAEAACcQAAAAEPCqX7LL54KFnlDMiUJV2VI2uGwNG3SeyggYrZqWhbFlQ7BRvWEKZnEp1/EMVgAZYQ==", "a38970d9-3b22-4581-95a2-f6258c72b959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5afa4d-bb08-445b-9add-2970c2b1d944", "AQAAAAEAACcQAAAAEGKfEp+vJ93jq2nKzabO02G2xTcFdh68/tTwunA6yLYlmebihHdASdnpJWyqiYdhnw==", "ed934d2e-8776-45fd-ad71-ae15665adf5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a361531a-d8ee-48f0-a22e-e48f5604d145", "AQAAAAEAACcQAAAAENSxPBeEqbEnMsVVt14VOit7zu3m+ArTBu4dsMrFTgf6AwYiIv7uKt5F/5uZkiyXQw==", "a6069084-831b-4c12-95ee-b5e307cb9f4e" });
        }
    }
}

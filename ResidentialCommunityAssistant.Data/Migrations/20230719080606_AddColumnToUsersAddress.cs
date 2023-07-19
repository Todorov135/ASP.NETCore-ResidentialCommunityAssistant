using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class AddColumnToUsersAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserHomeManager",
                table: "UsersAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "85d21beb-403e-487c-ac01-d08209de7b69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "e4025971-7bb2-4242-bdba-225be113c858");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6db305c-4b22-42ab-9af5-4d08bb592147", "AQAAAAEAACcQAAAAEMmr3Tgi3+J8/Eb2ANu2QsX9gkngpq/l9nI+BC7BPmmw4JYsoBll3kGtMvNWQ2+bPA==", "f3b9ca5f-1e6f-412e-a691-d1bb40459296" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d344717-beb0-4ff3-8d53-e6fee8200d8e", "AQAAAAEAACcQAAAAEI/EvplGqnH06VdVP+kf7VH6vejv5MYWqYJXJevshpub14JstCEIFergR/puDmiUug==", "a90ab7e1-a507-4746-81f0-803f2c3227f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1b78453-9a6c-42cc-99f7-113417155f23", "AQAAAAEAACcQAAAAEBshc435HVTfp49ZVX77J3lCQSTJcd3G5xhikzYqPn4gENYyEeNq9O8c888fC5rY/A==", "9213dbf8-12cf-47b1-867c-e77ce0205044" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserHomeManager",
                table: "UsersAddresses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "8026634c-6e11-451f-b16d-43d35ee6e8e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "1c16c1eb-4e94-4090-8d62-3d866aa4f1c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3d617c5-3e74-4d96-8fa6-d6f171e56926", "AQAAAAEAACcQAAAAEPewyGnFmr5v7+lwSoKXSVXgG3mJjZGenQ+z+NWdEpk3rLGs5jsvhS1dIkpNez+Kmw==", "2883f00b-6c53-4158-8c13-9a8128ae9056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d08719e8-0fac-43d4-823f-1297da9d1650", "AQAAAAEAACcQAAAAEG8D84KdWyWtM6VikGLYud55nNUb+9YuV4edo8pqrqosb3ad0Tsekl0crRKJnKADJg==", "20687be6-e898-4678-93aa-dc5fec6c468c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a59ba1a-5188-4ce5-b871-28afb24c94a1", "AQAAAAEAACcQAAAAEJhF/yITvR5hfgNsFBCR+OrK48nF8SQXAaHxw5sSC++6w62KOrIzJ97Gf18h/e0/JQ==", "2c8d2d36-e579-4c44-9aae-4d6cda37d7aa" });
        }
    }
}

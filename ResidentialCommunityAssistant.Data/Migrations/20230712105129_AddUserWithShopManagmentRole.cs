using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    public partial class AddUserWithShopManagmentRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "df52a94f-e70f-4872-a5a8-48631411afdb", "8815d5cc-c403-43e8-b2d3-40f57a8d1d61" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df52a94f-e70f-4872-a5a8-48631411afdb", "8815d5cc-c403-43e8-b2d3-40f57a8d1d61" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492c2f53-e30a-4da9-b639-e599ef6d7794",
                column: "ConcurrencyStamp",
                value: "13547841-235d-4aa2-a830-20c2f51cc258");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df52a94f-e70f-4872-a5a8-48631411afdb",
                column: "ConcurrencyStamp",
                value: "d7b1cdac-74bb-4893-80ec-e464c1a90263");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "579b52e0-38e4-4f41-a30f-31e72767c536",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4755adb-d7c6-45d9-a4f5-18f032a2e59a", "AQAAAAEAACcQAAAAELE1g1PCXZR9RXYQj+a3dCJ+kH3MnOvYbInGK5YlMaoYvK8dQ7iJPSyCHhRAbyeISQ==", "0d9769e1-98b9-4aee-b878-a5ab6e3a4690" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1903f883-2f51-4e83-adbf-93af77277988", "AQAAAAEAACcQAAAAECOyNGHXIUIvLjw5o4irYQjvR0LJcVB5jrz4IFp42/6cbRZ00mUAYeUFS1nVbHKfYg==", "f4f0d126-a3d4-4a40-99f7-560ebde08d41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc25a082-69ef-407b-9647-c902c78b6bf8", "AQAAAAEAACcQAAAAEHihJMjUgr6Dinr3E5hswRquaRJ37uVsWHoQI7071b16j9SepSa56wqOvw4LrlUaqQ==", "376089ed-bed5-4f59-9461-da0ded318b6e" });
        }
    }
}

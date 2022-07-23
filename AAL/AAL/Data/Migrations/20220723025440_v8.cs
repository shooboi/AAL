using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAL.Data.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "img",
                table: "Item",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "456c7737-16a6-4370-ba45-29d7bf6f4f40", "AQAAAAEAACcQAAAAEFx58kW20Br6K0iAeQfVpd04pA8Y4H9UHt5WoinKAmmKd4P/oADkeaL63m5G9e6vSw==", "75719c4a-3748-4a74-a7da-16949adf2251" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "img",
                table: "Item",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0825e237-8a73-4a28-9145-c0bc3406bab4", "AQAAAAEAACcQAAAAEAeNb0fV5kSmT3VXxC4b0FBnRc5vSrzo1VzM37v13dnCoygxeq+Z8b/Z1OCGYMc6QA==", "ac711acc-9121-4615-891a-ac52fad7344d" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AAL.Data.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0825e237-8a73-4a28-9145-c0bc3406bab4", "AQAAAAEAACcQAAAAEAeNb0fV5kSmT3VXxC4b0FBnRc5vSrzo1VzM37v13dnCoygxeq+Z8b/Z1OCGYMc6QA==", "ac711acc-9121-4615-891a-ac52fad7344d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3002da8-8203-4d2a-9936-99bf3658bfbc", "AQAAAAEAACcQAAAAEPj6U/az/hjO0ncUfCF6k65IylNCyFeSykHElTtom6UbRXaihKTByFnNSk81XIdgUQ==", "69b98eb7-5348-4881-850f-6250f3c384ac" });
        }
    }
}

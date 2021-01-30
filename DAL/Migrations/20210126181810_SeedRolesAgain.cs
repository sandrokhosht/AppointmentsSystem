using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedRolesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9775e4c-7775-4002-acec-45105c760db6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cca3ffae-fb0e-44b6-86ad-601ae20d241a", "71fd95df-7947-45de-b350-1cf4163ecf0f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54b1f0f6-2302-486c-8549-83faa90cc1de", "92b2d5d3-00e9-468a-940b-088aee3fb68f", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa07f18e-3826-4456-b6ff-8015d10ffd80", "9f91dd1d-f764-4516-a5f2-67c77ae8cd7a", "Doctor", "DOCTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b1f0f6-2302-486c-8549-83faa90cc1de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cca3ffae-fb0e-44b6-86ad-601ae20d241a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa07f18e-3826-4456-b6ff-8015d10ffd80");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9775e4c-7775-4002-acec-45105c760db6", "1616fc14-c8dd-4a3c-a22b-3c17a6d81fc7", "Admin", "ADMIN" });
        }
    }
}

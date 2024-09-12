using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LoginViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29380cd5-5542-4fb8-bc71-1c0f6f8136e9", null, "User", "USER" },
                    { "c0e2fbda-9707-408c-afec-aa229df3fe9e", null, "Manager", "MANAGER" },
                    { "e4f3efed-0c4f-4d64-bc65-9fefdc0ce439", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29380cd5-5542-4fb8-bc71-1c0f6f8136e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e2fbda-9707-408c-afec-aa229df3fe9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f3efed-0c4f-4d64-bc65-9fefdc0ce439");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LoginViewModel");
        }
    }
}

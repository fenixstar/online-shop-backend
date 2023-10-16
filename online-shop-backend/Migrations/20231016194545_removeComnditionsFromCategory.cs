using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace online_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class removeComnditionsFromCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "243aabde-1cd1-4c10-8762-0718260f5d93");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "299d2b84-ea04-4941-9b80-8de4e8764abc");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "ad128534-4e8a-4312-931e-bbcd12ca779e");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "663b9e9b-7b5b-40d0-a6b4-f50c88fb73cf", null, "User", "USER" },
                    { "90786458-d132-4e38-b092-ce5e860941cf", null, "Moderator", "MODERATOR" },
                    { "bada50d8-9a56-4b77-b621-777cf3a02396", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "663b9e9b-7b5b-40d0-a6b4-f50c88fb73cf");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "90786458-d132-4e38-b092-ce5e860941cf");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "bada50d8-9a56-4b77-b621-777cf3a02396");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "243aabde-1cd1-4c10-8762-0718260f5d93", null, "User", "USER" },
                    { "299d2b84-ea04-4941-9b80-8de4e8764abc", null, "Moderator", "MODERATOR" },
                    { "ad128534-4e8a-4312-931e-bbcd12ca779e", null, "Admin", "ADMIN" }
                });
        }
    }
}

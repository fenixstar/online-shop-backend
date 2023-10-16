using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace online_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFKSubCategory2Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "8c826831-d97f-4a38-8769-e8a741cc7c1e");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "9035584b-0a2e-45b5-98af-1a51b8f62f7a");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "b4f29ee4-7e83-4c98-8ec3-359e4ae470d7");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "8c826831-d97f-4a38-8769-e8a741cc7c1e", null, "Moderator", "MODERATOR" },
                    { "9035584b-0a2e-45b5-98af-1a51b8f62f7a", null, "User", "USER" },
                    { "b4f29ee4-7e83-4c98-8ec3-359e4ae470d7", null, "Admin", "ADMIN" }
                });
        }
    }
}

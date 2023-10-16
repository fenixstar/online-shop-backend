using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace online_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class changeSubcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "1af4c42f-ed9c-451f-902f-bc96ed081c5c");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "22edce5c-b0b4-4f6a-8853-ac8b6062e1bb");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "399d736d-9b0e-4031-86f9-f5cfb19263e2");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "subcategories",
                newName: "Title");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "subcategories",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1af4c42f-ed9c-451f-902f-bc96ed081c5c", null, "Moderator", "MODERATOR" },
                    { "22edce5c-b0b4-4f6a-8853-ac8b6062e1bb", null, "Admin", "ADMIN" },
                    { "399d736d-9b0e-4031-86f9-f5cfb19263e2", null, "User", "USER" }
                });
        }
    }
}

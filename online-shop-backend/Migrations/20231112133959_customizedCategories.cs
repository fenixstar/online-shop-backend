using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace online_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class customizedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "29e8a1a5-329d-4128-8ff6-e5caf308116f");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "4b09ceee-bbe9-44ae-a4da-3c02c456ffc5");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "5c5f99eb-46a9-4e2d-88ae-bf3d7df4c5de");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "subcategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "subcategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActual",
                table: "categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-dog", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-cat", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-rodent", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-fish", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-bird", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-snake", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-horse", true });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "617db7b5-fe30-4c30-94b0-00a7802b4b08", null, "User", "USER" },
                    { "8769c0d4-08f1-4b10-aeb1-5f763e592131", null, "Moderator", "MODERATOR" },
                    { "f07efd7d-6bce-4e52-9d8f-d7be738e45c5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-paw", true });

            migrationBuilder.UpdateData(
                table: "subcategories",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Icon", "IsActual" },
                values: new object[] { "mdi-bottle-tonic-plus", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "617db7b5-fe30-4c30-94b0-00a7802b4b08");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "8769c0d4-08f1-4b10-aeb1-5f763e592131");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "f07efd7d-6bce-4e52-9d8f-d7be738e45c5");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "subcategories");

            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "subcategories");

            migrationBuilder.DropColumn(
                name: "IsActual",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Icon",
                value: null);

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29e8a1a5-329d-4128-8ff6-e5caf308116f", null, "User", "USER" },
                    { "4b09ceee-bbe9-44ae-a4da-3c02c456ffc5", null, "Admin", "ADMIN" },
                    { "5c5f99eb-46a9-4e2d-88ae-bf3d7df4c5de", null, "Moderator", "MODERATOR" }
                });
        }
    }
}

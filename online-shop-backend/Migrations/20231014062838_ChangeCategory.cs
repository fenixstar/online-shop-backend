using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace online_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "16f7e772-cb28-4a63-86c8-da9839230c67");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "7a0816aa-31a8-4dbf-8ed7-1d4ecd8dae8c");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "f7478dfe-7f6e-40e6-8f8b-a6ca3467246c");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "categories",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Icon",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "categories");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "categories",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16f7e772-cb28-4a63-86c8-da9839230c67", null, "Moderator", "MODERATOR" },
                    { "7a0816aa-31a8-4dbf-8ed7-1d4ecd8dae8c", null, "User", "USER" },
                    { "f7478dfe-7f6e-40e6-8f8b-a6ca3467246c", null, "Admin", "ADMIN" }
                });
        }
    }
}

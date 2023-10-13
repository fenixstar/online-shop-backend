using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace online_shop_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "04be2a18-889f-491a-bea9-4f7c159e11bc");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "5d5f1611-12c7-4075-a568-f5feb8ccbaa7");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "c4d31c79-0cf9-4f96-baff-1572c61f01d7");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Собаки" },
                    { 2, "Кошки" },
                    { 3, "Грызуны" },
                    { 4, "Рыбы" },
                    { 5, "Птицы" },
                    { 6, "Риптилии" },
                    { 7, "Другие питомцы" },
                    { 8, "Уход и аксессуары" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16f7e772-cb28-4a63-86c8-da9839230c67", null, "Moderator", "MODERATOR" },
                    { "7a0816aa-31a8-4dbf-8ed7-1d4ecd8dae8c", null, "User", "USER" },
                    { "f7478dfe-7f6e-40e6-8f8b-a6ca3467246c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "subcategories",
                columns: new[] { "ID", "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Корм для собак" },
                    { 2, 1, "Игрушки для собак" },
                    { 3, 1, "Ошейники и поводкик" },
                    { 4, 1, "Туалеты" },
                    { 5, 1, "Миски и поилки" },
                    { 6, 2, "Корм для кошек" },
                    { 7, 2, "Игрушки для кошек" },
                    { 8, 2, "Ошейники и поводки" },
                    { 9, 2, "Когтеточки" },
                    { 10, 2, "Туалеты" },
                    { 11, 2, "Миски и поилки" },
                    { 12, 3, "Корм для грызунов" },
                    { 13, 3, "Вольеры и клетки" },
                    { 14, 3, "Игрушки для грызунов" },
                    { 15, 3, "Миски и поилки" },
                    { 16, 4, "Корм для рыбок" },
                    { 17, 4, "Прочая переферия для рыбок" },
                    { 18, 5, "Вольеры и клетки" },
                    { 19, 5, "Корм для птиц" },
                    { 20, 5, "Гнезда и гнездовые принадлежности" },
                    { 21, 6, "Террариумы" },
                    { 22, 6, "Корм для рептилий" },
                    { 23, 6, "Освещение и обогрев для террариумов" },
                    { 24, 7, "Мелкие животные" },
                    { 25, 7, "Корм и аксессуары для экзотических животных" },
                    { 26, 8, "Гигиенические средства" },
                    { 27, 8, "Посуда и кормушки" },
                    { 28, 8, "Лежанки и домики" },
                    { 29, 8, "Одежда и аксессуары" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "subcategories",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04be2a18-889f-491a-bea9-4f7c159e11bc", null, "User", "USER" },
                    { "5d5f1611-12c7-4075-a568-f5feb8ccbaa7", null, "Admin", "ADMIN" },
                    { "c4d31c79-0cf9-4f96-baff-1572c61f01d7", null, "Moderator", "MODERATOR" }
                });
        }
    }
}

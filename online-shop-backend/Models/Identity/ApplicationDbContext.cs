using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using online_shop_backend.Models.Entities;
using online_shop_backend.Utils;

namespace online_shop_backend.Models.Identity;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserDetail> UserDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<ProducerDetail> ProducerDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ShippingMethod> ShippingMethods { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserDetail>().ToTable("user_details");
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Producer>().ToTable("producers");
        modelBuilder.Entity<ProducerDetail>().ToTable("producer_details");
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<OrderDetail>().ToTable("order_details");
        modelBuilder.Entity<Category>()
            .ToTable("categories")
            .HasData(
                new Category { ID = 1, Name = "Собаки" },
                new Category { ID = 2, Name = "Кошки" },
                new Category { ID = 3, Name = "Грызуны" },
                new Category { ID = 4, Name = "Рыбы" },
                new Category { ID = 5, Name = "Птицы" },
                new Category { ID = 6, Name = "Риптилии" },
                new Category { ID = 7, Name = "Другие питомцы" },
                new Category { ID = 8, Name = "Уход и аксессуары" }
            );
        modelBuilder.Entity<Subcategory>()
            .ToTable("subcategories")
            .HasData(
                new Subcategory { ID = 1, CategoryID = 1, Name = "Корм для собак" },
                new Subcategory { ID = 2, CategoryID = 1, Name = "Игрушки для собак" },
                new Subcategory { ID = 3, CategoryID = 1, Name = "Ошейники и поводкик" },
                new Subcategory { ID = 4, CategoryID = 1, Name = "Туалеты" },
                new Subcategory { ID = 5, CategoryID = 1, Name = "Миски и поилки" },
                new Subcategory { ID = 6, CategoryID = 2, Name = "Корм для кошек" },
                new Subcategory { ID = 7, CategoryID = 2, Name = "Игрушки для кошек" },
                new Subcategory { ID = 8, CategoryID = 2, Name = "Ошейники и поводки" },
                new Subcategory { ID = 9, CategoryID = 2, Name = "Когтеточки" },
                new Subcategory { ID = 10, CategoryID = 2, Name = "Туалеты" },
                new Subcategory { ID = 11, CategoryID = 2, Name = "Миски и поилки" },
                new Subcategory { ID = 12, CategoryID = 3, Name = "Корм для грызунов" },
                new Subcategory { ID = 13, CategoryID = 3, Name = "Вольеры и клетки" },
                new Subcategory { ID = 14, CategoryID = 3, Name = "Игрушки для грызунов" },
                new Subcategory { ID = 15, CategoryID = 3, Name = "Миски и поилки" },
                new Subcategory { ID = 16, CategoryID = 4, Name = "Корм для рыбок" },
                new Subcategory { ID = 17, CategoryID = 4, Name = "Прочая переферия для рыбок" },
                new Subcategory { ID = 18, CategoryID = 5, Name = "Вольеры и клетки" },
                new Subcategory { ID = 19, CategoryID = 5, Name = "Корм для птиц" },
                new Subcategory { ID = 20, CategoryID = 5, Name = "Гнезда и гнездовые принадлежности" },
                new Subcategory { ID = 21, CategoryID = 6, Name = "Террариумы" },
                new Subcategory { ID = 22, CategoryID = 6, Name = "Корм для рептилий" },
                new Subcategory { ID = 23, CategoryID = 6, Name = "Освещение и обогрев для террариумов" },
                new Subcategory { ID = 24, CategoryID = 7, Name = "Мелкие животные" },
                new Subcategory { ID = 25, CategoryID = 7, Name = "Корм и аксессуары для экзотических животных" },
                new Subcategory { ID = 26, CategoryID = 8, Name = "Гигиенические средства" },
                new Subcategory { ID = 27, CategoryID = 8, Name = "Посуда и кормушки" },
                new Subcategory { ID = 28, CategoryID = 8, Name = "Лежанки и домики" },
                new Subcategory { ID = 29, CategoryID = 8, Name = "Одежда и аксессуары" });
        modelBuilder.Entity<PaymentType>().ToTable("payment_types");
        modelBuilder.Entity<PaymentMethod>().ToTable("payment_methods");
        modelBuilder.Entity<Review>().ToTable("reviews");
        modelBuilder.Entity<ShippingMethod>().ToTable("shipping_methods");
        modelBuilder.Entity<Invoice>().ToTable("invoices");
        modelBuilder.Entity<InvoiceDetail>().ToTable("invoice_details");
        modelBuilder.Entity<Discount>().ToTable("discounts");
        modelBuilder.Entity<RefreshToken>().ToTable("refresh_tokens");
        modelBuilder.Entity<IdentityRole>().ToTable("roles")
            .HasData(new { Id = Guid.NewGuid().ToString(), Name = Constants.USER, NormalizedName = Constants.USER.ToUpper() },
                new { Id = Guid.NewGuid().ToString(), Name = Constants.ADMIN, NormalizedName = Constants.ADMIN.ToUpper() },
                new { Id = Guid.NewGuid().ToString(), Name = Constants.MODERATOR, NormalizedName = Constants.MODERATOR.ToUpper() });
    }
}
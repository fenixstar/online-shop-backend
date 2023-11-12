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

    public DbSet<ProductPicture> ProductPictures { get; set; }


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
                new Category { Id = 1, Title = "Собаки", Icon = "mdi-dog", IsActual = true },
                new Category { Id = 2, Title = "Кошки", Icon = "mdi-cat", IsActual = true },
                new Category { Id = 3, Title = "Грызуны", Icon = "mdi-rodent", IsActual = true },
                new Category { Id = 4, Title = "Рыбы", Icon = "mdi-fish", IsActual = true },
                new Category { Id = 5, Title = "Птицы", Icon = "mdi-bird", IsActual = true },
                new Category { Id = 6, Title = "Риптилии", Icon = "mdi-snake", IsActual = true },
                new Category { Id = 7, Title = "Другие питомцы", Icon = "mdi-horse", IsActual = true },
                new Category { Id = 8, Title = "Уход и аксессуары", Icon = "mdi-paw", IsActual = true }
            );


        modelBuilder.Entity<Subcategory>()
            .ToTable("subcategories")
            .HasData(
                new Subcategory
                    { Id = 1, CategoryId = 1, Title = "Корм для собак", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 2, CategoryId = 1, Title = "Игрушки для собак", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 3, CategoryId = 1, Title = "Ошейники и поводкик", Icon = "mdi-paw", IsActual = true },
                new Subcategory { Id = 4, CategoryId = 1, Title = "Туалеты", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 5, CategoryId = 1, Title = "Миски и поилки", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 6, CategoryId = 2, Title = "Корм для кошек", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 7, CategoryId = 2, Title = "Игрушки для кошек", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 8, CategoryId = 2, Title = "Ошейники и поводки", Icon = "mdi-paw", IsActual = true },
                new Subcategory { Id = 9, CategoryId = 2, Title = "Когтеточки", Icon = "mdi-paw", IsActual = true },
                new Subcategory { Id = 10, CategoryId = 2, Title = "Туалеты", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 11, CategoryId = 2, Title = "Миски и поилки", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 12, CategoryId = 3, Title = "Корм для грызунов", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 13, CategoryId = 3, Title = "Вольеры и клетки", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 14, CategoryId = 3, Title = "Игрушки для грызунов", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 15, CategoryId = 3, Title = "Миски и поилки", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 16, CategoryId = 4, Title = "Корм для рыбок", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                {
                    Id = 17, CategoryId = 4, Title = "Прочая переферия для рыбок", Icon = "mdi-paw", IsActual = true
                },
                new Subcategory
                    { Id = 18, CategoryId = 5, Title = "Вольеры и клетки", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 19, CategoryId = 5, Title = "Корм для птиц", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                {
                    Id = 20, CategoryId = 5, Title = "Гнезда и гнездовые принадлежности", Icon = "mdi-paw",
                    IsActual = true
                },
                new Subcategory { Id = 21, CategoryId = 6, Title = "Террариумы", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 22, CategoryId = 6, Title = "Корм для рептилий", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                {
                    Id = 23, CategoryId = 6, Title = "Освещение и обогрев для террариумов", Icon = "mdi-paw",
                    IsActual = true
                },
                new Subcategory
                    { Id = 24, CategoryId = 7, Title = "Мелкие животные", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                {
                    Id = 25, CategoryId = 7, Title = "Корм и аксессуары для экзотических животных", Icon = "mdi-paw",
                    IsActual = true
                },
                new Subcategory
                    { Id = 26, CategoryId = 8, Title = "Гигиенические средства", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 27, CategoryId = 8, Title = "Посуда и кормушки", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 28, CategoryId = 8, Title = "Лежанки и домики", Icon = "mdi-paw", IsActual = true },
                new Subcategory
                    { Id = 29, CategoryId = 8, Title = "Одежда и аксессуары", Icon = "mdi-bottle-tonic-plus", IsActual = true });

        modelBuilder.Entity<Subcategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Subcategories)
            .HasForeignKey(x => x.CategoryId)
            .IsRequired();

        modelBuilder.Entity<PaymentType>().ToTable("payment_types");
        modelBuilder.Entity<PaymentMethod>().ToTable("payment_methods");
        modelBuilder.Entity<Review>().ToTable("reviews");
        modelBuilder.Entity<ShippingMethod>().ToTable("shipping_methods");
        modelBuilder.Entity<Invoice>().ToTable("invoices");
        modelBuilder.Entity<InvoiceDetail>().ToTable("invoice_details");
        modelBuilder.Entity<Discount>().ToTable("discounts");
        modelBuilder.Entity<RefreshToken>().ToTable("refresh_tokens");
        modelBuilder.Entity<IdentityRole>().ToTable("roles")
            .HasData(
                new
                {
                    Id = Guid.NewGuid().ToString(), Name = Constants.User, NormalizedName = Constants.User.ToUpper()
                },
                new
                {
                    Id = Guid.NewGuid().ToString(), Name = Constants.Admin, NormalizedName = Constants.Admin.ToUpper()
                },
                new
                {
                    Id = Guid.NewGuid().ToString(), Name = Constants.Moderator,
                    NormalizedName = Constants.Moderator.ToUpper()
                });

        modelBuilder.Entity<ProductPicture>().ToTable("product_pictures");

        modelBuilder.Entity<ProductPicture>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPictures)
            .HasForeignKey(x => x.ProductId);
    }
}
using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations;

public class EfProductRepository(ApplicationDbContext context) : IProductRepository
{
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void RemoveProduct(Product product)
    {
        context.Products.Remove(product);
        context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        context.Products.Update(product);
        context.SaveChanges();
    }

    public Product GetProduct(long id)
    {
        return context.Products.Find(id);
    }

    public ICollection<Product> GetAllProducts()
    {
        return context.Products.ToList();
    }

    public Producer GetProducerForProduct(long id)
    {
        return context.Producers.Find(
            context.Products.Find(id)?.ProducerId
        );
    }

    public Category GetCategoryForProduct(long id)
    {
        return context.Categories.Find(
            context.Products.Find(id)?.CategoryId
        );
    }

    public Subcategory GetSubcategoryForProduct(long id)
    {
        return context.Subcategories.Find(
            context.Products.Find(id)?.SubcategoryId
        );
    }

    public ICollection<Review> GetReviewsForProduct(long id)
    {
        return context.Reviews.Where(r => r.ProductId == id).ToList();
    }

    public ICollection<Discount> GetDiscountsForProduct(long id)
    {
        return context.Discounts.Where(d => d.ProductId == id).ToList();
    }

    public bool CheckIfProductIsAvailable(long id, int neededQuantity = 0)
    {
        return context.Products.Find(id).AvailableQuantity > neededQuantity;
    }
}
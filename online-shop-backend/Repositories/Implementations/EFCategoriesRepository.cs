using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations;

public class EfCategoriesRepository(ApplicationDbContext context) : ICategoriesRepository
{
    public void AddCategory(CategoryDto category)
    {
        context.Categories.Add(new Category { Title = category.Title });
        context.SaveChanges();
    }

    public void RemoveCategory(Category category)
    {
        context.Categories.Remove(category);
        context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        context.Update(category);
        context.SaveChanges();
    }

    public Category GetCategory(int id)
    {
        return context.Categories.Find(id);
    }

    public ICollection<Category> GetAllCategories()
    {
        return context.Categories
            .Include(x => x.Subcategories)
            .Where(x => x.IsActual)
            .ToList();
    }

    public ICollection<Subcategory> GetSubcategoriesForCategory(int id)
    {
        return context.Subcategories.Where(s => s.CategoryId == id).ToList();
    }

    public ICollection<Product> GetProductsForCategory(int id, int page = 1, int limit = 20)
    {
        return context.Products.Where(p => p.CategoryId == id)
            .Skip((page - 1) * limit).Take(limit)
            .ToList();
    }
}
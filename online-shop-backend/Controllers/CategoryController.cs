using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers;

[Route("/api/category")]
public class CategoryController(ICategoriesRepository categoriesRepository) : Controller
{
    [HttpGet]
    public ICollection<Category> Index()
    {
        return categoriesRepository.GetAllCategories();
    }

    [HttpGet("{id:required}")]
    public CategoryPageDto Category(int id, int? page, int? limit)
    {
        var result = new CategoryPageDto
        {
            Category = categoriesRepository.GetCategory(id),
            Subcategories = categoriesRepository.GetSubcategoriesForCategory(id),
            Products = categoriesRepository.GetProductsForCategory(id, page ?? 1, limit ?? 20)
        };

        return result;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create([FromBody] CategoryDto category)
    {
        categoriesRepository.AddCategory(category);
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id:required}")]
    public IActionResult Delete(int id)
    {
        categoriesRepository.RemoveCategory(categoriesRepository.GetCategory(id));
        return Ok();
    }
}
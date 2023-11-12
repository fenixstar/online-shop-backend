using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.Utils;

namespace online_shop_backend.Controllers;

[Route("/api/category")]
public class CategoryController(ICategoriesRepository categoriesRepository, IMapperBase mapper) : Controller
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

    [HttpPost]
    [Authorize(Roles = Constants.Moderator)]
    public IActionResult Create([FromBody] CategoryDto category)
    {
        categoriesRepository.AddCategory(category);
        return Ok();
    }

    [HttpDelete("{id:required}")]
    [Authorize(Roles = Constants.Moderator)]
    public IActionResult Delete(int id)
    {
        categoriesRepository.RemoveCategory(categoriesRepository.GetCategory(id));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = Constants.Moderator)]
    public IActionResult Update([FromBody] CategoryDto category)
    {
        categoriesRepository.UpdateCategory(mapper.Map<Category>(category));
        return Ok();
    }
}
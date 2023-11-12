using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.Utils;

namespace online_shop_backend.Controllers;

[Route("/api/subcategory")]
public class SubcategoryController(ISubcategoriesRepository subcategoriesRepository,
        IProducerRepository producerRepository)
    : Controller
{
    [HttpGet]
    public ICollection<Subcategory> Index()
    {
        return subcategoriesRepository.GetAllSubcategories();
    }
    
    [HttpPost]
    [Authorize(Roles = Constants.Moderator)]
    public IActionResult AddSubcategory([FromBody] Subcategory subcategory)
    {
        subcategoriesRepository.AddSubcategory(subcategory);
        return Ok();
    }

    [HttpDelete("{id:required}")]
    [Authorize(Roles = Constants.Moderator)]
    public IActionResult RemoveSubcategory([FromQuery] int id)
    {
        var sc = subcategoriesRepository.GetSubcategory(id);
        subcategoriesRepository.RemoveSubcategory(sc);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = Constants.Moderator)]
    public IActionResult UpdateSubcategory([FromBody] Subcategory subcategory)
    {
        subcategoriesRepository.UpdateSubcategory(subcategory);
        return Ok();
    }
}
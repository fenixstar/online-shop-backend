using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers;

[Route("/api/subcategory")]
public class SubcategoryController : Controller
{
    private readonly IProducerRepository producerRepository;
    private readonly ISubcategoriesRepository subcategoriesRepository;

    public SubcategoryController(ISubcategoriesRepository subcategoriesRepository,
        IProducerRepository producerRepository)
    {
        this.subcategoriesRepository = subcategoriesRepository;
        this.producerRepository = producerRepository;
    }

    [HttpGet]
    public ICollection<Subcategory> Index()
    {
        return subcategoriesRepository.GetAllSubcategories();
    }

    [HttpGet("{id:required}")]
    public SubcategoryPageDto Subcategory(int id, int? page, int? limit)
    {
        var result = new SubcategoryPageDto
        {
            Subcategory = subcategoriesRepository.GetSubcategory(id),
            Products = subcategoriesRepository.GetProductsForSubcategory(id, page ?? 1, limit ?? 20)
        };

        foreach (var product in result.Products)
            product.Producer = producerRepository.GetProducer(product.ProducerId);

        return result;
    }
}
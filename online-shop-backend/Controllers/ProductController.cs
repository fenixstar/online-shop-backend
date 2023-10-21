using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers;

[Route("/api/product")]
public class ProductController(IProductRepository productRepository, IDiscountRepository discountRepository)
    : Controller
{
    [HttpGet("{id:required}")]
    public Product Index(long id)
    {
        var result = productRepository.GetProduct(id);
        result.Producer = productRepository.GetProducerForProduct(id);
        result.Category = productRepository.GetCategoryForProduct(id);
        result.Subcategory = productRepository.GetSubcategoryForProduct(id);
        result.Discounts = productRepository.GetDiscountsForProduct(id);

        return result;
    }

    [HttpGet("selected")]
    public List<Product> GetSelectedProducts([FromQuery] int[] ids)
    {
        var results = ids?.Select(id => productRepository.GetProduct(id)).ToList();

        foreach (var product in results) product.Producer = productRepository.GetProducerForProduct(product.Id);

        return results;
    }

    [HttpGet("discounts")]
    public ICollection<Discount> Discounts()
    {
        return discountRepository.GetAllDiscounts();
    }

    [HttpGet("list")]
    public ICollection<Product> List(int categoryId, int subCategoryId)
    {
        var products = productRepository
            .GetAllProducts()
            .Where(p => p.CategoryId == categoryId && p.SubcategoryId == subCategoryId)
            .ToList();

        return products;
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] Product product)
    {
        productRepository.AddProduct(product);
        return Ok();
    }

    [HttpDelete("{id:required}")]
    [Authorize]
    public IActionResult Delete(long id)
    {
        productRepository.RemoveProduct(productRepository.GetProduct(id));
        return Ok();
    }
    
    [HttpPut]
    [Authorize]
    public IActionResult Update([FromBody] Product product)
    {
        productRepository.UpdateProduct(product);
        return Ok(product);
    }
    
    [HttpGet("available")]
    public bool CheckIfProductIsAvailable(long id, int neededQuantity = 0)
    {
        return productRepository.CheckIfProductIsAvailable(id, neededQuantity);
    }
}
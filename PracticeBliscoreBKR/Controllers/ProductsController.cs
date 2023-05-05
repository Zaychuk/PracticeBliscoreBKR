using Microsoft.AspNetCore.Mvc;
using PracticeBliscoreBKR.Dtos;
using PracticeBliscoreBKR.Services;

namespace PracticeBliscoreBKR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("create/default")]
    public void CreateDefaultProducts()
    {
        _productService.CreateDefaultProducts();
    }

    [HttpGet("all")]
    public List<ProductDto> GetAllProducts()
    {
        var products = _productService.GetAllProducts();

        return products;
    }

    [HttpGet("byName")]
    public ProductDto GetProductByName(string name)
    {
        var product = _productService.GetProductByName(name);

        return product;
    }

    [HttpGet("isAvailable")]
    public bool CheckIfProductIsAvailable(string name)
    {
        var product = _productService.GetProductByName(name);

        return product.IsAvailable;
    }

    [HttpGet("byManufacturer")]
    public List<ProductDto> GetProductsByManufacturer(string manufacturer)
    {
        var products = _productService.GetProductsByManufacturer(manufacturer);

        return products;
    }

    [HttpGet("byCategoty")]
    public List<ProductDto> GetProductsByCategory(string category)
    {
        var products = _productService.GetProductsByCategory(category);

        return products;
    }
}

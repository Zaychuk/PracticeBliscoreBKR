using Microsoft.AspNetCore.Mvc;
using PracticeBliscoreBKR.WebApi.Dtos;
using PracticeBliscoreBKR.WebApi.Services;
using PracticeBliscoreBKR.WebApi.Validators;

namespace PracticeBliscoreBKR.WebApi.Controllers;

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
    public void Create13DefaultProducts()
    {
        _productService.Create13DefaultProducts();
    }

    [HttpPost("create")]
    public ActionResult<Guid> CreateProduct(CreateProductDto dto)
    {
        ProductsValidator.ValidateCreateProductDto(dto);
        return _productService.CreateProduct(dto);
    }

    [HttpGet("all")]
    public ActionResult<List<ProductDto>> GetAllProducts()
    {
        var products = _productService.GetAllProducts();

        return products;
    }

    [HttpGet("byName")]
    public ActionResult<ProductDto> GetProductByName(string name)
    {
        var product = _productService.GetProductByName(name);

        return product;
    }

    [HttpGet("byId")]
    public ActionResult<ProductDto> GetProductById(Guid id)
    {
        var product = _productService.GetProductById(id);

        return product;
    }

    [HttpGet("isAvailable")]
    public ActionResult<bool> CheckIfProductIsAvailable(string name)
    {
        var product = _productService.GetProductByName(name);

        return product.IsAvailable;
    }

    [HttpGet("byManufacturer")]
    public ActionResult<List<ProductDto>> GetProductsByManufacturer(string manufacturer)
    {
        var products = _productService.GetProductsByManufacturer(manufacturer);

        return products;
    }

    [HttpGet("byCategoty")]
    public ActionResult<List<ProductDto>> GetProductsByCategory(string category)
    {
        var products = _productService.GetProductsByCategory(category);

        return products;
    }
}

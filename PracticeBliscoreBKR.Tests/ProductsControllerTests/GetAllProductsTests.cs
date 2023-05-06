using PracticeBliscoreBKR.Mappers;
using PracticeBliscoreBKR.WebApi.Controllers;
using PracticeBliscoreBKR.WebApi.Repositories;
using PracticeBliscoreBKR.WebApi.Services;

namespace PracticeBliscoreBKR.Tests.ProductsControllerTests;

public class GetAllProductsTests
{
    private readonly ProductsController _sutController;

    public GetAllProductsTests()
    {
        _sutController = new ProductsController(new ProductService(new ProductRepository(), new AutoMapperConfigure().GetMapper()));
    }

    [Fact]
    public void GetAllProducts_Success()
    {
        // Arrange
        _sutController.Create13DefaultProducts();

        // Act
        var result = _sutController.GetAllProducts();

        // Assert
        Assert.NotEmpty(result.Value);
    }

    [Fact]
    public void GetAllProducts_Success_WhenEmptyList()
    {
        // Act
        var result = _sutController.GetAllProducts();

        // Assert
        Assert.Empty(result.Value);
    }
}
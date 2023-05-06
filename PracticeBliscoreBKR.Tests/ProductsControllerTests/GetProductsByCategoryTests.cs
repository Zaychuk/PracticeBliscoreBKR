using PracticeBliscoreBKR.Mappers;
using PracticeBliscoreBKR.Controllers;
using PracticeBliscoreBKR.Repositories;
using PracticeBliscoreBKR.Services;

namespace PracticeBliscoreBKR.Tests.ProductsControllerTests;

public class GetProductsByCategoryTests
{
    private readonly ProductsController _sutController;

    public GetProductsByCategoryTests()
    {
        _sutController = new ProductsController(new ProductService(new ProductRepository(), new AutoMapperConfigure().GetMapper()));
    }

    [Fact]
    public void GetProductsByCategory_Success()
    {
        // Arrange
        var category = "Fashion";
        _sutController.Create13DefaultProducts();

        // Act
        var result = _sutController.GetProductsByCategory(category);

        // Assert
        Assert.NotEmpty(result?.Value);
        Assert.Equal(3, result?.Value.Count);
    }

    [Fact]
    public void GetProductsByCategory_Success_WhenEmptyList()
    {
        // Arrange
        var category = "Fashion";

        // Act
        var result = _sutController.GetProductsByCategory(category);

        // Assert
        Assert.Empty(result.Value);
    }
}

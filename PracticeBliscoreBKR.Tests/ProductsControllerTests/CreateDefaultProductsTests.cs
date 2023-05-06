using PracticeBliscoreBKR.Mappers;
using PracticeBliscoreBKR.Controllers;
using PracticeBliscoreBKR.Repositories;
using PracticeBliscoreBKR.Services;

namespace PracticeBliscoreBKR.Tests.ProductsControllerTests;

public class CreateDefaultProductsTests
{
    private readonly ProductsController _sutController;

    public CreateDefaultProductsTests()
    {
        _sutController = new ProductsController(new ProductService(new ProductRepository(), new AutoMapperConfigure().GetMapper()));
    }

    [Fact]
    public void CreateDefaultProducts_Success()
    {
        // Arrange
        _sutController.Create13DefaultProducts();

        // Act
        var result = _sutController.GetAllProducts();

        // Assert
        Assert.NotNull(result.Value);
        Assert.NotEmpty(result.Value);
        Assert.Equal(13, result.Value.Count);
    }
}

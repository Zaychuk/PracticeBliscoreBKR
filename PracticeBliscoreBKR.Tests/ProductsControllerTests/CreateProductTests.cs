using PracticeBliscoreBKR.Mappers;
using PracticeBliscoreBKR.Controllers;
using PracticeBliscoreBKR.Dtos;
using PracticeBliscoreBKR.Repositories;
using PracticeBliscoreBKR.Services;

namespace PracticeBliscoreBKR.Tests.ProductsControllerTests;

public class CreateProductTests
{
    private readonly ProductsController _sutController;

    public CreateProductTests()
    {
        _sutController = new ProductsController(new ProductService(new ProductRepository(), new AutoMapperConfigure().GetMapper()));
    }

    [Fact]
    public void CreateProduct_Exception_WhenDtoIsNull()
    {
        // Arrange
        CreateProductDto dto = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _sutController.CreateProduct(dto));
    }

    [Fact]
    public void CreateProduct_Exception_WhenNameIsNullOrWhiteSpace()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Description = "description",
            Category = "category",
            Manufacturer = "manufacturer",
            Price = 10,
            Stock = 1
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sutController.CreateProduct(dto));
    }

    [Fact]
    public void CreateProduct_Exception_WhenDescriptionIsNullOrWhiteSpace()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "name",
            Description = "   ",
            Category = "category",
            Manufacturer = "manufacturer",
            Price = 10,
            Stock = 1
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sutController.CreateProduct(dto));
    }

    [Fact]
    public void CreateProduct_Exception_WhenStockIsNegativeNumber()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "name",
            Description = "description",
            Category = "category",
            Manufacturer = "manufacturer",
            Price = 10,
            Stock = -1
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sutController.CreateProduct(dto));
    }

    [Fact]
    public void CreateProduct_Exception_WhenPriceIsNegativeNumber()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "name",
            Description = "description",
            Category = "category",
            Manufacturer = "manufacturer",
            Price = -19.99m,
            Stock = 1
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _sutController.CreateProduct(dto));
    }

    [Fact]
    public void CreateProduct_Success()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Name = "name of the product",
            Description = "description",
            Category = "category",
            Manufacturer = "manufacturer",
            Price = 19.99m,
            Stock = 1
        };
        // Act 
        var result = _sutController.CreateProduct(dto);

        // Assert
        Assert.IsType<Guid>(result.Value);

        var createdProduct = _sutController.GetProductById(result.Value);

        Assert.NotNull(createdProduct.Value);
        Assert.Equal(dto.Name, createdProduct.Value.Name);
        Assert.Equal(dto.Description, createdProduct.Value.Description);
        Assert.Equal(dto.Category, createdProduct.Value.Category);
        Assert.Equal(dto.Manufacturer, createdProduct.Value.Manufacturer);
        Assert.Equal(dto.Price, createdProduct.Value.Price);
        Assert.Equal(dto.Stock, createdProduct.Value.Stock);
        Assert.True(createdProduct.Value.IsAvailable);
    }

}

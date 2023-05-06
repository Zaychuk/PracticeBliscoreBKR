using AutoMapper;
using PracticeBliscoreBKR.WebApi.Dtos;
using PracticeBliscoreBKR.WebApi.Entities;
using PracticeBliscoreBKR.WebApi.Repositories;

namespace PracticeBliscoreBKR.WebApi.Services;

public interface IProductService
{
    bool CheckIfProductIsAvailable(string name);
    void Create13DefaultProducts();
    List<ProductDto> GetAllProducts();
    ProductDto GetProductByName(string name);
    ProductDto GetProductById(Guid id);
    List<ProductDto> GetProductsByCategory(string category);
    List<ProductDto> GetProductsByManufacturer(string manufacturer);
    Guid CreateProduct(CreateProductDto product);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public void Create13DefaultProducts()
    {
        _productRepository.Create13DefaultProducts();
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _productRepository.GetAllProducts();

        return products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
    }

    public ProductDto GetProductByName(string name)
    {
        var product = _productRepository.GetProductByName(name);

        return _mapper.Map<ProductDto>(product);
    }

    public ProductDto GetProductById(Guid id)
    {
        var product = _productRepository.GetProductById(id);

        return _mapper.Map<ProductDto>(product);
    }

    public bool CheckIfProductIsAvailable(string name)
    {
        var product = _productRepository.GetProductByName(name);

        return _mapper.Map<ProductDto>(product).IsAvailable;
    }

    public List<ProductDto> GetProductsByManufacturer(string manufacturer)
    {
        var products = _productRepository.GetProductsByManufacturer(manufacturer);

        return products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
    }

    public List<ProductDto> GetProductsByCategory(string category)
    {
        var products = _productRepository.GetProductsByCategory(category);

        return products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
    }

    public Guid CreateProduct(CreateProductDto dto)
    {
        var product = _mapper.Map<ProductEntity>(dto);
        product.Id = Guid.NewGuid();
        _productRepository.CreateProduct(product);

        return product.Id;
    }
}

using AutoMapper;
using PracticeBliscoreBKR.Dtos;
using PracticeBliscoreBKR.Repositories;

namespace PracticeBliscoreBKR.Services;

public interface IProductService
{
    bool CheckIfProductIsAvailable(string name);
    void CreateDefaultProducts();
    List<ProductDto> GetAllProducts();
    ProductDto GetProductByName(string name);
    List<ProductDto> GetProductsByCategory(string category);
    List<ProductDto> GetProductsByManufacturer(string manufacturer);
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

    public void CreateDefaultProducts()
    {
        _productRepository.CreateDefaultProducts();
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
}

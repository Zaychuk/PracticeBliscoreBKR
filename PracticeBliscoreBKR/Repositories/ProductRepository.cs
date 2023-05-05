using PracticeBliscoreBKR.Entities;

namespace PracticeBliscoreBKR.Repositories;

public interface IProductRepository
{
    void CreateDefaultProducts();
    List<ProductEntity> GetAllProducts();
    ProductEntity GetProductByName(string name);
    List<ProductEntity> GetProductsByCategory(string category);
    List<ProductEntity> GetProductsByManufacturer(string manufacturer);
}

public class ProductRepository : IProductRepository
{
    private List<ProductEntity> ProductsDatabase = new List<ProductEntity>();

    public List<ProductEntity> GetAllProducts()
    {
        return ProductsDatabase;
    }

    public ProductEntity GetProductByName(string name)
    {
        return ProductsDatabase.FirstOrDefault(p => p.Name == name);
    }

    public List<ProductEntity> GetProductsByManufacturer(string manufacturer)
    {
        return ProductsDatabase.Where(p => p.Manufacturer == manufacturer).ToList();
    }

    public List<ProductEntity> GetProductsByCategory(string category)
    {
        return ProductsDatabase.Where(p => p.Category == category).ToList();
    }

    public void CreateDefaultProducts()
    {
        ProductsDatabase.Clear();
        ProductsDatabase.AddRange(new List<ProductEntity>
        {
            new ProductEntity("Apple MacBook Air", "Lightweight laptop with Retina display", 999.99m, 50, "https://example.com/macbookair.jpg", "Apple", "Electronics"),
            new ProductEntity("Nike Air Max 270 React", "Comfortable sneakers with modern design", 150m, 100, "https://example.com/airmax270.jpg", "Nike", "Fashion"),
            new ProductEntity("Fitbit Versa 2", "Smartwatch with fitness tracking features", 199.99m, 25, "https://example.com/fitbitversa2.jpg", "Fitbit", "Electronics"),
            new ProductEntity("Sony WH-1000XM4", "Wireless noise-cancelling headphones", 349.99m, 10, "https://example.com/sonywh1000xm4.jpg", "Sony", "Electronics"),
            new ProductEntity("KitchenAid Artisan Stand Mixer", "Powerful and versatile kitchen appliance", 499.99m, 20, "https://example.com/kitchenaid.jpg", "KitchenAid", "Home & Kitchen"),
            new ProductEntity("Patagonia Nano Puff Jacket", "Warm and lightweight jacket for outdoor activities", 199m, 30, "https://example.com/patagoniananopuff.jpg", "Patagonia", "Fashion"),
            new ProductEntity("Samsung QLED TV", "High-end smart TV with advanced features", 1499.99m, 5, "https://example.com/samsungqled.jpg", "Samsung", "Electronics"),
            new ProductEntity("Bose QuietComfort Earbuds", "Wireless noise-cancelling earbuds", 279m, 15, "https://example.com/boseqc.jpg", "Bose", "Electronics"),
            new ProductEntity("Le Creuset Dutch Oven", "Durable and versatile cast iron cooking pot", 389.95m, 12, "https://example.com/lecreuset.jpg", "Le Creuset", "Home & Kitchen\r\n"),
            new ProductEntity("Fujifilm X-T4 Camera", "High-performance mirrorless camera with advanced features", 1699m, 8, "https://example.com/fujifilmxt4.jpg", "Fujifilm", "Electronics"),
            new ProductEntity("Philips Sonicare Electric Toothbrush", "Advanced dental care product with rechargeable battery", 99.99m, 40, "https://example.com/philipssonicare.jpg", "Philips", "Health & Beauty"),
            new ProductEntity("Patagonia Better Sweater", "Warm and comfortable sweater made from recycled materials", 139m, 25, "https://example.com/patagoniabettersweater.jpg", "Patagonia", "Fashion"),
            new ProductEntity("Dyson V11 Cordless Vacuum", "Powerful and versatile vacuum cleaner with advanced features", 699.99m, 7, "https://example.com/dysonv11.jpg", "Dyson", "Home & Kitchen"),
        });
    }
}

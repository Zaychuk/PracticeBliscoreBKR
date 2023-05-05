namespace PracticeBliscoreBKR.Entities;

public class ProductEntity
{
    public ProductEntity(string name, string description, decimal price, int stock, string imageUrl, string manufacturer, string category)
    {
        Id =  Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        ImageUrl = imageUrl;
        Manufacturer = manufacturer;
        Category = category;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public string Manufacturer { get; set; }
    public string Category { get; set; }
}

using PracticeBliscoreBKR.Dtos;

namespace PracticeBliscoreBKR.Validators;

public static class ProductsValidator
{
    public static void ValidateCreateProductDto(CreateProductDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }
        if(string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length < 5)
        {
            throw new ArgumentException($"{nameof(dto.Name)}: is not provided or invalid");
        }
        if(string.IsNullOrWhiteSpace(dto.Description) || dto.Description.Length < 5)
        {
            throw new ArgumentException($"{nameof(dto.Description)}: is not provided or invalid");
        }
        if( dto.Stock < 0)
        {
            throw new ArgumentException($"{nameof(dto.Stock)}: cannot be negative");
        }
        if( dto.Price < 0)
        {
            throw new ArgumentException($"{nameof(dto.Price)}: cannot be negative");
        }
        if (string.IsNullOrWhiteSpace(dto.Manufacturer) || dto.Manufacturer.Length < 3)
        {
            throw new ArgumentException($"{nameof(dto.Manufacturer)}: is not provided or invalid");
        }
        if (string.IsNullOrWhiteSpace(dto.Category) || dto.Category.Length < 3)
        {
            throw new ArgumentException($"{nameof(dto.Category)}: is not provided or invalid");
        }
    }
}

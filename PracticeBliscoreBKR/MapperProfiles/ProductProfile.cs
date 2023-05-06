using AutoMapper;
using PracticeBliscoreBKR.WebApi.Dtos;
using PracticeBliscoreBKR.WebApi.Entities;

namespace PracticeBliscoreBKR.MapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductDto>()
            .ForMember(dto => dto.IsAvailable, opt => opt.MapFrom(ent => ent.Stock > 0));

        CreateMap<CreateProductDto, ProductEntity>()
            .ForMember(dto => dto.Id, opt => opt.Ignore());
    }
}

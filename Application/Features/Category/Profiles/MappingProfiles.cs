using Application.Features.Category.Commands.Create;
using Application.Features.Category.Queries.GetCategoryList;
using AutoMapper;

namespace Application.Features.Category.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Category, GetCategoryListItemDto>().ReverseMap();

        CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Category, CreatedCategoryResponse>().ReverseMap();
    }
}
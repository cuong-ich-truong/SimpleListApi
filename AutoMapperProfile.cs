using AutoMapper;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Category, SimpleCategoryDto>();
      CreateMap<Category, ReadCategoryDto>();

      CreateMap<LineItem, SimpleLineItemDto>();
      CreateMap<LineItem, ReadLineItemDto>();
      CreateMap<CreateLineItemDto, LineItem>();
    }
  }
}
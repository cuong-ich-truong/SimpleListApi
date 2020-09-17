using AutoMapper;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Category, ReadCategoryDto>();

      CreateMap<LineItem, ReadLineItemDto>();
      CreateMap<CreateLineItemDto, LineItem>();
    }
  }
}
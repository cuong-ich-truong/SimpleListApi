using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi.Services.CategoryService
{
  public class CategoryService : ICategoryService
  {
    private static List<Category> _categories = new List<Category>
    {
      new Category("Electronic"),
      new Category("Clothing"),
      new Category("Kitchen"),
    };

    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public async Task<ServiceResponse<List<ReadCategoryDto>>> GetAll()
    {
      return new ServiceResponse<List<ReadCategoryDto>> { Data = _mapper.Map<List<ReadCategoryDto>>(_categories) };
    }
  }
}
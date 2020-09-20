using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleListApi.Contexts;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi.Services.CategoryService
{
  public class CategoryService : ICategoryService
  {
    private readonly IMapper _mapper;
    private readonly SimpleListContext _context;

    public CategoryService(IMapper mapper, SimpleListContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task<ServiceResponse<List<ReadCategoryDto>>> GetAll()
    {
      var categories = await _context.Categories.ToListAsync();
      return new ServiceResponse<List<ReadCategoryDto>> { Data = _mapper.Map<List<ReadCategoryDto>>(categories) };
    }
  }
}
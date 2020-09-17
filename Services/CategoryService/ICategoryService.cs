using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi.Services.CategoryService
{
  public interface ICategoryService
  {
    Task<ServiceResponse<List<ReadCategoryDto>>> GetAll();
  }
}
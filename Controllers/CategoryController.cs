using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleListApi.Models;
using SimpleListApi.Services.CategoryService;

namespace SimpleListApi.Controllers
{
  [ApiController]
  [Route("api/categories")]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get()
    {
      return Ok(await _categoryService.GetAll());
    }
  }
}
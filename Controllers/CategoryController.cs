using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleListApi.Dtos;
using SimpleListApi.Models;
using SimpleListApi.Services.CategoryService;
using SimpleListApi.Services.LineItemService;

namespace SimpleListApi.Controllers
{
  [ApiController]
  [Route("api/categories")]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    private readonly ILineItemService _lineItemService;

    public CategoryController(ICategoryService categoryService, ILineItemService lineItemService)
    {
      _categoryService = categoryService;
      _lineItemService = lineItemService;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadCategoryDto>>> Get()
    {
      return Ok(await _categoryService.GetAll());
    }

    [HttpGet]
    [Route("{id}/lineitems")]
    public async Task<ActionResult<List<ReadLineItemDto>>> GetLineItemsByCategoryId(Guid id)
    {
      var response = await _lineItemService.GetByCategoryId(id);
      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }
  }
}
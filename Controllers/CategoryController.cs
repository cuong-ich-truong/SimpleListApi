using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleListApi.Models;

namespace SimpleListApi.Controllers
{
  [ApiController]
  [Route("api/categories")]
  public class CategoryController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
      var items = new List<Category>();
      items.Add(new Category("Electronic"));
      items.Add(new Category("Clothing"));
      items.Add(new Category("Kitchen"));

      return Ok(items);
    }
  }
}
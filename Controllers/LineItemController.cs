using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleListApi.Models;

namespace SimpleListApi.Controllers
{
  [ApiController]
  [Route("api/lineitems")]
  public class LineItemController : ControllerBase
  {
    private static List<LineItem> lineItems = new List<LineItem>{
      new LineItem("TV", 2000),
      new LineItem("Playstation", 400),
      new LineItem("Stereo", 1600),
    };

    [HttpGet]
    public ActionResult<IEnumerable<LineItem>> Get()
    {
      return Ok(lineItems);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<LineItem> GetById(Guid id)
    {
      return Ok(lineItems.FirstOrDefault(e => e.Id == id));
    }

    [HttpPost]
    public ActionResult<LineItem> AddLineItem(LineItem item)
    {
      var newItem = new LineItem(item.Name, item.Price);
      lineItems.Add(newItem);
      return Ok(newItem);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<LineItem> DeleteLineItem(Guid id)
    {
      var item = lineItems.FirstOrDefault(e => e.Id == id);
      if (item != null)
      {
        lineItems.Remove(item);
      }

      return Ok(item);
    }
  }
}
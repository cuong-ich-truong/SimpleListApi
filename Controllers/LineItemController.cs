using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleListApi.Dtos;
using SimpleListApi.Services.LineItemService;

namespace SimpleListApi.Controllers
{
  [ApiController]
  [Route("api/lineitems")]
  public class LineItemController : ControllerBase
  {
    private readonly ILineItemService _lineItemService;

    public LineItemController(ILineItemService lineItemService)
    {
      _lineItemService = lineItemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadLineItemDto>>> Get()
    {
      return Ok(await _lineItemService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ReadLineItemDto>> GetById(Guid id)
    {
      var response = await _lineItemService.GetById(id);
      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ReadLineItemDto>> CreateLineItem(CreateLineItemDto item)
    {
      return Ok(await _lineItemService.CreateLineItem(item));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<ReadLineItemDto>> DeleteLineItem(Guid id)
    {
      var response = await _lineItemService.DeleteLineItem(id);

      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }
  }
}
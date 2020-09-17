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
      return Ok(await _lineItemService.GetById(id));
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
      return Ok(await _lineItemService.DeleteLineItem(id));
    }
  }
}
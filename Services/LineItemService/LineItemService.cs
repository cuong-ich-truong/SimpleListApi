using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi.Services.LineItemService
{
  public class LineItemService : ILineItemService
  {
    private static List<LineItem> _lineItems = new List<LineItem>
    {
      new LineItem("TV", 2000),
      new LineItem("Playstation", 400),
      new LineItem("Stereo", 1600),
    };

    private readonly IMapper _mapper;

    public LineItemService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public async Task<ServiceResponse<List<ReadLineItemDto>>> GetAll()
    {
      return new ServiceResponse<List<ReadLineItemDto>> { Data = _mapper.Map<List<ReadLineItemDto>>(_lineItems) };
    }

    public async Task<ServiceResponse<ReadLineItemDto>> GetById(Guid id)
    {
      var item = _lineItems.FirstOrDefault(e => e.Id == id);

      if (item != null)
      {
        return new ServiceResponse<ReadLineItemDto> { Data = _mapper.Map<ReadLineItemDto>(item) };
      }

      return new ServiceResponse<ReadLineItemDto> { Data = null, Message = "Item not found", Success = false };;
    }

    public async Task<ServiceResponse<ReadLineItemDto>> CreateLineItem(CreateLineItemDto newItem)
    {
      var item = _mapper.Map<LineItem>(newItem);
      _lineItems.Add(item);

      return new ServiceResponse<ReadLineItemDto> { Data = _mapper.Map<ReadLineItemDto>(item) };
    }

    public async Task<ServiceResponse<ReadLineItemDto>> DeleteLineItem(Guid id)
    {
      var item = _lineItems.FirstOrDefault(e => e.Id == id);
      if (item != null)
      {
        _lineItems.Remove(item);
        return new ServiceResponse<ReadLineItemDto> { Data = _mapper.Map<ReadLineItemDto>(item) };
      }

      return new ServiceResponse<ReadLineItemDto> { Data = null, Message = "Item not found", Success = false };;
    }

  }
}
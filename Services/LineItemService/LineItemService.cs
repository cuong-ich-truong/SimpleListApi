using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleListApi.Contexts;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi.Services.LineItemService
{
  public class LineItemService : ILineItemService
  {

    private readonly IMapper _mapper;
    private readonly SimpleListContext _context;

    public LineItemService(IMapper mapper, SimpleListContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task<ServiceResponse<List<ReadLineItemDto>>> GetAll()
    {
      var items = await _context.LineItems.ToListAsync();
      return new ServiceResponse<List<ReadLineItemDto>>
      {
        Data = _mapper.Map<List<ReadLineItemDto>>(items)
      };
    }

    public async Task<ServiceResponse<ReadLineItemDto>> GetById(Guid id)
    {
      var item = await _context.LineItems.FindAsync(id);

      if (item != null)
      {
        return new ServiceResponse<ReadLineItemDto> { Data = _mapper.Map<ReadLineItemDto>(item) };
      }

      return new ServiceResponse<ReadLineItemDto> { Data = null, Message = "Item not found", Success = false };;
    }

    public async Task<ServiceResponse<ReadLineItemDto>> CreateLineItem(CreateLineItemDto newItem)
    {
      var item = _mapper.Map<LineItem>(newItem);
      _context.LineItems.Add(item);
      await _context.SaveChangesAsync();

      return new ServiceResponse<ReadLineItemDto> { Data = _mapper.Map<ReadLineItemDto>(item) };
    }

    public async Task<ServiceResponse<ReadLineItemDto>> DeleteLineItem(Guid id)
    {
      var item = _context.LineItems.FirstOrDefault(e => e.Id == id);
      if (item != null)
      {
        _context.LineItems.Remove(item);
        await _context.SaveChangesAsync();

        return new ServiceResponse<ReadLineItemDto> { Data = _mapper.Map<ReadLineItemDto>(item) };
      }

      return new ServiceResponse<ReadLineItemDto> { Data = null, Message = "Item not found", Success = false };;
    }

  }
}
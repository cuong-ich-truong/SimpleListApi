using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleListApi.Dtos;
using SimpleListApi.Models;

namespace SimpleListApi.Services.LineItemService
{
  public interface ILineItemService
  {
    Task<ServiceResponse<List<ReadLineItemDto>>> GetAll();

    Task<ServiceResponse<ReadLineItemDto>> GetById(Guid id);

    Task<ServiceResponse<List<ReadLineItemDto>>> GetByCategoryId(Guid categoryId);

    Task<ServiceResponse<ReadLineItemDto>> CreateLineItem(CreateLineItemDto newItem);

    Task<ServiceResponse<ReadLineItemDto>> DeleteLineItem(Guid id);
  }
}
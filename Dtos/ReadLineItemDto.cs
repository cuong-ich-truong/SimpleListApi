using System;

namespace SimpleListApi.Dtos
{
  public class ReadLineItemDto
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
  }
}
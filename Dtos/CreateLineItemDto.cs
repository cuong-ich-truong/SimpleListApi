using System;

namespace SimpleListApi.Dtos
{
  public class CreateLineItemDto
  {
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
  }
}
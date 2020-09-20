using System;
using System.Collections.Generic;

namespace SimpleListApi.Dtos
{
  public class ReadCategoryDto
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<SimpleLineItemDto> LineItems { get; set; }
  }
}
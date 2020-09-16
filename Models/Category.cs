using System;

namespace SimpleListApi.Models
{
  public class Category
  {
    public Category(string name)
    {
      this.Id = Guid.NewGuid();
      this.Name = name;

    }
    public Guid Id { get; set; }

    public string Name { get; set; }
  }
}
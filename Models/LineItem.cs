using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleListApi.Models
{
  public class LineItem
  {
    public LineItem()
    {

    }
    public LineItem(string name, decimal price, Guid categoryId)
    {
      this.Id = Guid.NewGuid();
      this.Name = name;
      this.Price = price;
      this.CategoryId = categoryId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }
  }
}
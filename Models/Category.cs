using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleListApi.Models
{
  public class Category
  {
    public Category(string name)
    {
      this.Id = Guid.NewGuid();
      this.Name = name;
      this.LineItems = new List<LineItem>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<LineItem> LineItems { get; set; }
  }
}
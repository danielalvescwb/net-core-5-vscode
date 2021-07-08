using System;
using System.ComponentModel.DataAnnotations.Schema;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities
{
  [Table("books")]
  public class Book : BaseEntity
  {
    [Column("title")]
    public string Title { get; set; }

    [Column("author")]
    public string Author { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("launch_date")]
    public DateTime LaunchDate { get; set; }
  }
}
using System.ComponentModel.DataAnnotations.Schema;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities
{
  [Table("person")]
  public class Person : BaseEntity
  {
    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("address")]
    public string Address { get; set; }
    [Column("gender")]
    public string Gender { get; set; }
  }
}
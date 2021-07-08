using Microsoft.EntityFrameworkCore;

namespace restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.context
{
  public class MSSQLContext : DbContext
  {
    public MSSQLContext()
    {
    }
    public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
    {
    }
    public DbSet<restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities.Person> Persons { get; set; }
    public DbSet<restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities.Book> Books { get; set; }
  }
}
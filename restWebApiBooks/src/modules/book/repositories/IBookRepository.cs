using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.shared.repositories;

namespace restWebApiBooks.src.modules.book.infra.repositories
{
  public interface IBookRepository : IGenericRepository<Book>
  {
    // Add methods only for IBookRepository
  }
}
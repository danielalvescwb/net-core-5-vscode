using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.shared.repositories;
// using restWebApiBooks.Model;

namespace restWebApiBooks.src.modules.person
{
  public interface IPersonRepository : IGenericRepository<Person>
  {
    // Add methods only for IPersonRepository
  }
}
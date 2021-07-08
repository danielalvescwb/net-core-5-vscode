using System.Collections.Generic;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.shared.repositories
{
  public interface IGenericRepository<T> where T : BaseEntity
  {
    List<T> FindAll();
    T FindById(int id);
    T Create(T item);
    T Update(T item);
    void Delete(int id);
  }
}
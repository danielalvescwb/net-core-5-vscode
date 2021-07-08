using System.Collections.Generic;
using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.book.infra.repositories;
using restWebApiBooks.src.modules.shared.repositories;

namespace restWebApiBooks.src.modules.book.infra.entityFrameworkCore.repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly IGenericRepository<Book> _repository;

    public BookRepository(IGenericRepository<Book> repository)
    {
      _repository = repository;
    }
    public List<Book> FindAll()
    {
      return _repository.FindAll();
    }
    public Book FindById(int id)
    {
      return _repository.FindById(id);
    }
    public Book Create(Book book)
    {
      return _repository.Create(book);
    }
    public Book Update(Book book)
    {
      return _repository.Update(book);
    }
    public void Delete(int id)
    {
      _repository.Delete(id);
    }
  }
}
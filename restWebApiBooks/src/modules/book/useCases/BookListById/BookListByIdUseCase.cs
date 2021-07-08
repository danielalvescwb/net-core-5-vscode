using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  class BookListByIdUseCase : ControllerBase
  {
    private IBookRepository _repository;

    public BookListByIdUseCase(IBookRepository bookRepository){
      _repository = bookRepository;
    }
    public IActionResult execute(int id)
    {
      Book book = _repository.FindById(id);
      if (book == null) return NotFound();
      return Ok(book);
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  class BookCreateUseCase : ControllerBase
  {
    private IBookRepository _repository;
    public BookCreateUseCase(IBookRepository bookRepository)
    {
      _repository = bookRepository;
    }
    public IActionResult execute(Book book)
    {
      if (book == null) return BadRequest();
      return Ok(_repository.Create(book));
    }
  }
}
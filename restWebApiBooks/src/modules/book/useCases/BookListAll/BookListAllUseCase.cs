using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  class BookListAllUseCase : ControllerBase
  {
    private IBookRepository _repository;
    public BookListAllUseCase(IBookRepository bookRepository)
    {
      _repository = bookRepository;
    }
    public IActionResult execute()
    {
      return Ok(_repository.FindAll());
    }
  }
}
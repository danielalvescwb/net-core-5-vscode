using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  class BookUDeleteUseCase : ControllerBase
  {
    private IBookRepository _repository;

    public BookUDeleteUseCase(IBookRepository bookRepository)
    {
      _repository = bookRepository;
    }
    public IActionResult execute(int id)
    {
      _repository.Delete(id);
      return NoContent();
    }
  }
}
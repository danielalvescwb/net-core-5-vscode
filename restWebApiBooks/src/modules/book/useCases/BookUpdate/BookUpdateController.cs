using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/book")]
  public class BookUpdateController : ControllerBase
  {
    private readonly ILogger<BookUpdateController> _logger;
    private IBookRepository _repository;
    public BookUpdateController(
      ILogger<BookUpdateController> logger,
      IBookRepository bookRepository
    )
    {
      _logger = logger;
      _repository = bookRepository;
    }
    [HttpPut]
    public IActionResult Put([FromBody] Book book)
    {
      return new BookUpdateUseCase(_repository).execute(book);
    }
  }
}


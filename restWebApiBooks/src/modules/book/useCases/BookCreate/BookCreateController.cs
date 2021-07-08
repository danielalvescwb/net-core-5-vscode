using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/book")]
  public class BookCreateController : ControllerBase
  {
    private readonly ILogger<BookCreateController> _logger;
    private IBookRepository _repository;
    public BookCreateController(
      ILogger<BookCreateController> logger,
      IBookRepository bookRepository
    )
    {
      _logger = logger;
      _repository = bookRepository;
    }
    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
      return new BookCreateUseCase(_repository).execute(book);
    }
  }
}


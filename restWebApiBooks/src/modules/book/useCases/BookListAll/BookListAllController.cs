using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/book")]
  public class BookListAllController : ControllerBase
  {
    private readonly ILogger<BookListAllController> _logger;
    private IBookRepository _repository;
    public BookListAllController(
      ILogger<BookListAllController> logger,
      IBookRepository bookRepository
    )
    {
      _logger = logger;
      _repository = bookRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
      return new BookListAllUseCase(_repository).execute();
    }
  }
}


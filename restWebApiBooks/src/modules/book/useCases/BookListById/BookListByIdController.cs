using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/book")]
  public class BookListByIdController : ControllerBase
  {
    private readonly ILogger<BookListByIdController> _logger;
    private IBookRepository _repository;
    public BookListByIdController(
      ILogger<BookListByIdController> logger,
      IBookRepository bookRepository
    )
    {
      _logger = logger;
      _repository = bookRepository;
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return new BookListByIdUseCase(_repository).execute(id);
    }
  }
}


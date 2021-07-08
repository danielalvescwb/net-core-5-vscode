using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.book.infra.repositories;

namespace restWebApiBooks.src.modules.book.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/book")]
  public class BookUDeleteController : ControllerBase
  {
    private readonly ILogger<BookUDeleteController> _logger;
    private IBookRepository _repository;
    public BookUDeleteController(
      ILogger<BookUDeleteController> logger,
      IBookRepository bookRepository
    )
    {
      _logger = logger;
      _repository = bookRepository;
    }
    [HttpPut]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return new BookUDeleteUseCase(_repository).execute(id);
    }
  }
}


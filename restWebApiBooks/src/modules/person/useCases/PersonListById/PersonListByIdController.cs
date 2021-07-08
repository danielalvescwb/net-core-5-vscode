using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace restWebApiBooks.src.modules.person.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/person")]
  public class PersonListByIdController : ControllerBase
  {
    private readonly ILogger<PersonListByIdController> _logger;
    private IPersonRepository _repository;
    public PersonListByIdController(
        ILogger<PersonListByIdController> logger,
        IPersonRepository personRepository
    )
    {
      _logger = logger;
      _repository = personRepository;
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return new PersonListByIdUseCase(_repository).execute(id);
    }
  }
}

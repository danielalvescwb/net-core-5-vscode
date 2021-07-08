using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace restWebApiBooks.src.modules.person.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/person")]
  public class PersonListAllController : ControllerBase
  {
    private readonly ILogger<PersonListAllController> _logger;
    private IPersonRepository _repository;
    public PersonListAllController(
        ILogger<PersonListAllController> logger,
        IPersonRepository personRepository
    )
    {
      _logger = logger;
      _repository = personRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
      return new PersonListAllUsecase(_repository).execute();
    }
  }
}

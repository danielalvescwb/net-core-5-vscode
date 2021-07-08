using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.person.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/person")]
  public class PersonCreateController : ControllerBase
  {
    private readonly ILogger<PersonListAllController> _logger;
    private IPersonRepository _repository;
    public PersonCreateController(
        ILogger<PersonListAllController> logger,
        IPersonRepository personRepository
    )
    {
      _logger = logger;
      _repository = personRepository;
    }
    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
      return new PersonCreateUseCase(_repository).execute(person);
    }
  }
}

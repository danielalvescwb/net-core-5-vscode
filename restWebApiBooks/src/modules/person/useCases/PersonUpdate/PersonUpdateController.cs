using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.person.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/person")]
  public class PersonUpdateController : ControllerBase
  {
    private readonly ILogger<PersonUpdateController> _logger;
    private IPersonRepository _repository;
    public PersonUpdateController(
        ILogger<PersonUpdateController> logger,
        IPersonRepository personRepository
    )
    {
      _logger = logger;
      _repository = personRepository;
    }
    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
      return new PersonUpdateUseCase(_repository).execute(person);
    }
  }
}

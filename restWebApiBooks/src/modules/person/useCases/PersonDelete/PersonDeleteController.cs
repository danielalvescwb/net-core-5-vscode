using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace restWebApiBooks.src.modules.person.useCases
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/v{version:apiVersion}/person")]
  public class PersonDeleteController : ControllerBase
  {
    private readonly ILogger<PersonDeleteController> _logger;
    private IPersonRepository _repository;
    public PersonDeleteController(
        ILogger<PersonDeleteController> logger,
        IPersonRepository personRepository
    )
    {
      _logger = logger;
      _repository = personRepository;
    }
    [HttpDelete("{id}") ]
    public IActionResult Delete(int id)
    {
      return new PersonDeleteUseCase(_repository).execute(id);
    }
  }
}

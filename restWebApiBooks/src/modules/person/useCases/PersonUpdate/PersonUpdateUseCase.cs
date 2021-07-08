using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.person.useCases
{
  public class PersonUpdateUseCase : ControllerBase
  {
    private IPersonRepository _repository;
    public PersonUpdateUseCase(
        IPersonRepository personRepository
    )
    {
      _repository = personRepository;
    }
    [HttpPut]
    public IActionResult execute([FromBody] Person person)
    {
      if (person == null) return BadRequest();
      Person perosnUpdate = _repository.Update(person);
      if (perosnUpdate == null) return NotFound();
      return Ok(perosnUpdate);
    }
  }
}

using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.person.useCases
{
  public class PersonCreateUseCase : ControllerBase
  {
    private IPersonRepository _repository;
    public PersonCreateUseCase(
        IPersonRepository personRepository
    )
    {
      _repository = personRepository;
    }
    public IActionResult execute(Person person)
    {
      if (person == null) return BadRequest();
      return Ok(_repository.Create(person));
    }
  }
}

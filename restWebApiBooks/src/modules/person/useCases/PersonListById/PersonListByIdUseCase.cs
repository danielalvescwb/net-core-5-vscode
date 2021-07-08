using Microsoft.AspNetCore.Mvc;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;

namespace restWebApiBooks.src.modules.person.useCases
{
  public class PersonListByIdUseCase : ControllerBase
  {
    private IPersonRepository _repository;
    public PersonListByIdUseCase(
        IPersonRepository personRepository
    )
    {
      _repository = personRepository;
    }
    public IActionResult execute(int id)
    {
      Person person = _repository.FindById(id);
      if (person == null) return NotFound();
      return Ok(person);
    }
  }
}

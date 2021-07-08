using Microsoft.AspNetCore.Mvc;

namespace restWebApiBooks.src.modules.person.useCases
{
  public class PersonDeleteUseCase : ControllerBase
  {
    private IPersonRepository _repository;
    public PersonDeleteUseCase(
        IPersonRepository personRepository
    )
    {
      _repository = personRepository;
    }
    [HttpDelete("{id}") ]
    public IActionResult execute(int id)
    {
      _repository.Delete(id);
      return NoContent();
    }
  }
}

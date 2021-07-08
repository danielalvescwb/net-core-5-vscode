using Microsoft.AspNetCore.Mvc;

namespace restWebApiBooks.src.modules.person.useCases
{
  public class PersonListAllUsecase : ControllerBase
  {
    private IPersonRepository _repository;
    public PersonListAllUsecase(
        IPersonRepository personRepository
    )
    {
      _repository = personRepository;
    }
    public IActionResult execute()
    {
      return Ok(_repository.FindAll());
    }
  }
}

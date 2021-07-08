using System.Collections.Generic;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.shared.repositories;

namespace restWebApiBooks.src.modules.person.infra.entityFrameworkCore.repositories
{
  public class PersonRepository : IPersonRepository
  {
    private readonly IGenericRepository<Person> _repository;
    public PersonRepository(
      IGenericRepository<Person> repository
    )
    {
      _repository = repository;
    }
    public List<Person> FindAll()
    {
      return _repository.FindAll();
    }
    public Person FindByID(int id)
    {
      throw new System.NotImplementedException();
    }
    public Person FindById(int id)
    {
      Person person = new Person();
      try
      {
        person = _repository.FindById(id);
      }
      catch (System.Exception)
      {
        throw;
      }
      return person;
    }
    public Person Create(Person person)
    {
      return _repository.Create(person);
    }
    public Person Update(Person person)
    {
      return _repository.Update(person);
    }
    public void Delete(int id)
    {
      _repository.Delete(id);
    }
  }
}
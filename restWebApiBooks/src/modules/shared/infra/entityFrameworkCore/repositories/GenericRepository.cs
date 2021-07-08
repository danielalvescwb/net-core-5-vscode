using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.context;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.entities;
using restWebApiBooks.src.modules.shared.repositories;

namespace restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.repositories
{
  class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    private DbSet<T> dataset;
    private readonly MSSQLContext _mssqlContext;
    public GenericRepository(
      MSSQLContext mssqlContext
    )
    {
      _mssqlContext = mssqlContext;
      dataset = _mssqlContext.Set<T>();
    }
    public List<T> FindAll()
    {
      return dataset.ToList();
    }
    public T FindById(int id)
    {
      return dataset.SingleOrDefault(p => p.Id.Equals(id));
    }
    public T Create(T item)
    {
      try
      {
        dataset.Add(item);
        _mssqlContext.SaveChanges();
        return item;
      }
      catch (Exception)
      {
        throw;
      }
    }
    public T Update(T item)
    {
      if (!Exists(item.Id)) return null;
      var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
      if (result != null)
      {
        try
        {
          _mssqlContext.Entry(result).CurrentValues.SetValues(item);
          _mssqlContext.SaveChanges();
          return item;
        }
        catch (System.Exception)
        {
          throw;
        }
      }
      else
      {
        return null;
      }
    }
    public void Delete(int id)
    {
      var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
      if (result != null)
      {
        try
        {
          dataset.Remove(result);
          _mssqlContext.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }
    private bool Exists(int id)
    {
      return dataset.Any(p => p.Id.Equals(id));
    }
  }
}
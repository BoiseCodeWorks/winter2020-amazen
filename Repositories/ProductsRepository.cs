using System;
using System.Collections.Generic;
using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Product> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Product GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Product Create(Product newProduct)
    {
      throw new NotImplementedException();
    }

    internal Product Edit(Product update)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
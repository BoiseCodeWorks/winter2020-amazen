using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Product> GetAll()
    {
      return _repo.GetAll();
    }

    internal Product GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Product Create(Product newProd)
    {
      return _repo.Create(newProd);
    }

    internal Product Edit(Product updated)
    {
      // REVIEW
      var data = GetById(updated.Id);
      updated.Description = updated.Description != null ? updated.Description : data.Description;
      updated.Title = updated.Title != null && updated.Title.Length > 2 ? updated.Title : data.Title;
      return _repo.Edit(updated);
    }
    internal string Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "delorted";
    }
  }
}
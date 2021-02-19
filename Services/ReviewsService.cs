using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepository _repo;

    public ReviewsService(ReviewsRepository repo)
    {
      _repo = repo;
    }

    internal Review GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Review Create(Review newProd)
    {
      return _repo.Create(newProd);
    }

    internal Review Edit(Review updated)
    {
      // REVIEW
      var data = GetById(updated.Id);
      updated.Body = updated.Body != null ? updated.Body : data.Body;
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
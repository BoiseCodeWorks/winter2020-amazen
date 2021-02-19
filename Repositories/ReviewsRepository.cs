using System;
using System.Collections.Generic;
using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class ReviewsRepository
  {
    private readonly IDbConnection _db;

    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Review GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Review Create(Review newReview)
    {
      throw new NotImplementedException();
    }

    internal Review Edit(Review update)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
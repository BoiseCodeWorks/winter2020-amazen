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
      string sql = "SELECT * FROM reviews WHERE id = @id;";
      return _db.QueryFirstOrDefault<Review>(sql, new { id });
    }

    //  Without POPUTLATE
    // internal IEnumerable<Review> GetByProductId(int id)
    // {
    //   string sql = "SELECT * FROM reviews WHERE productId = @id;";
    //   return _db.Query<Review>(sql, new { id });
    // }

    // POPULATING PRODUCT
    internal IEnumerable<Review> GetByProductId(int id)
    {
      string sql = @"
      SELECT 
      r.*,
      prod.*
      FROM reviews r 
      JOIN products prod ON r.productId = prod.id
      WHERE productId = @id;";


      return _db.Query<Review, Product, Review>(sql, (review, product) =>
      {
        review.Product = product;
        return review;
      }, new { id }, splitOn: "id");
    }

    internal Review Create(Review newReview)
    {
      string sql = @"
      INSERT INTO reviews
      (title, body, rating, productId)
      VALUES
      (@Title, @Body, @Rating, @ProductId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newReview);
      newReview.Id = id;
      return newReview;
    }

    internal Review Edit(Review update)
    {
      string sql = @"
      UPDATE FROM reviews
      SET
       body = @Body,
       title = @Title,
       rating = @Rating
      WHERE id = @Id";
      _db.Execute(sql, update);
      return update;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM reviews WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}
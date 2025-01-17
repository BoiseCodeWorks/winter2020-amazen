using System.ComponentModel.DataAnnotations;

namespace AmaZen.Models
{
  public class Review
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
  }
}
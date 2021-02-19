using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  public class ProductsController : ControllerBase
  {
    public ProductsController(ProductsService ps)
    {

    }
  }
}
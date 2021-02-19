using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _service;

    public ProductsController(ProductsService ps)
    {
      _service = ps;
    }

    [HttpGet]
    public ActionResult<Product> Get()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product newProd)
    {
      try
      {
        return Ok(_service.Create(newProd));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Edit([FromBody] Product updated, int id)
    {
      try
      {
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
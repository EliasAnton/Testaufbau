﻿using Microsoft.AspNetCore.Mvc;
using Testaufbau.DataAccess;
using Testaufbau.Models;

namespace Testaufbau.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly MariaDbContext _mariaDbContext;

    public ProductsController(MariaDbContext mariaDbContext)
    {
        _mariaDbContext = mariaDbContext;
    }

    [HttpGet]
    public ActionResult Get(int take = 10, int skip = 0)
    {
        return Ok(_mariaDbContext.Articles!.OrderBy(a => a.ArticleId).Skip(skip).Take(take));
    }

    [HttpGet("all")]
    public ActionResult GetAllProducts()
    {
        return Ok(_mariaDbContext.Articles!.ToList());
    }

}
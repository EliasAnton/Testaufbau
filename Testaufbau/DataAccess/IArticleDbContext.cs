using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public interface IArticleDbContext
{
    DbSet<Article>? Articles { get; set; }
    DbSet<Price>? Prices { get; set; }
}
using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public interface IMariaDbContext
{
    DbSet<Article>? Articles { get; set; }
    DbSet<Order>? Orders { get; set; }
    DbSet<OrderItem>? OrderItems { get; set; }
}
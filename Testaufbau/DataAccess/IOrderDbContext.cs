using Microsoft.EntityFrameworkCore;
using Testaufbau.DataAccess.Models;

namespace Testaufbau.DataAccess;

public interface IOrderDbContext
{
    DbSet<Order>? Orders { get; set; }
    DbSet<OrderItem>? OrderItems { get; set; }
}
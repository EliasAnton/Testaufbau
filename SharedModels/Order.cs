﻿using System.ComponentModel.DataAnnotations;

namespace Testaufbau;

public class Order
{
    [Key]
    public int Id { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string CustomerName { get; set; }
    public int CustomerAddressId { get; set; }
    public string CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }

}
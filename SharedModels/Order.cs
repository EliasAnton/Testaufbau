namespace Testaufbau;

public class Order
{
    public int OrderId { get; set; }
    List<OrderItem> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public int CustomerAddressId { get; set; }
    public string CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    public decimal TotalPrice { get; set; }

}
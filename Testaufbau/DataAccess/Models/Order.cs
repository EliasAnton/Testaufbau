using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
[ProtoInclude(2, typeof(OrderItem))]
public class Order
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public List<OrderItem>? OrderItems { get; set; }

    [ProtoMember(3)]
    public DateTime OrderDate { get; set; }

    [ProtoMember(4)]
    public decimal TotalPrice { get; set; }

    [ProtoMember(5)]
    public string CustomerName { get; set; }

    [ProtoMember(6)]
    public string? CustomerEmail { get; set; }

    [ProtoMember(7)]
    public string? CustomerPhone { get; set; }

}
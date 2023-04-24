using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
[ProtoInclude(3, typeof(Order))]
[ProtoInclude(5, typeof(Article))]
public class OrderItem
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ForeignKey(nameof(Order))]
    [ProtoMember(2)]
    public int OrderId { get; set; }

    [ProtoMember(3)]
    public Order? Order { get; set; }

    [ForeignKey(nameof(Article))]
    [ProtoMember(4)]
    public int ArticleId { get; set; }

    [ProtoMember(5)]
    public Article? Article { get; set; }

    [ProtoMember(6)]
    public int Quantity { get; set; }
}
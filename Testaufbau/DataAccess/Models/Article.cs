using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
[ProtoInclude(5, typeof(Price))]
public class Article
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(4)]
    public string? Description { get; set; }

    [ForeignKey(nameof(Price))]
    [ProtoMember(5)]
    public int PriceId { get; set; }
    
    [ProtoMember(6)]
    public Price? Price { get; set; }

    [ProtoMember(7)]
    public int Sku { get; set; }
}
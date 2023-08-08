using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
[ProtoInclude(6, typeof(Price))]
public class Article
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public int Sku { get; set; }
    
    [ProtoMember(4)]
    public string? Description { get; set; }

    [ForeignKey(nameof(Price))]
    [ProtoMember(5)]
    public int PriceId { get; set; }

    [ProtoMember(6)]
    public Price? Price { get; set; }

    [ProtoMember(7)]
    public bool? IsActive { get; set; }
    
    [ProtoMember(8)]
    public string? Color { get; set; }
    
    [ProtoMember(9)]
    public decimal? Width { get; set; }
    
    [ProtoMember(10)]
    public decimal? Height { get; set; }
    
    [ProtoMember(11)]
    public decimal? Depth { get; set; }
    
    [ProtoMember(12)]
    public decimal? Weight { get; set; }
    
    [ProtoMember(13)]
    public string? Material { get; set; }
}
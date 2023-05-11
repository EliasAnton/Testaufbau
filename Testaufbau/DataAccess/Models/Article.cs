using System.ComponentModel.DataAnnotations;
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

    [ProtoMember(5)]
    public Price Price { get; set; }

    [ProtoMember(6)]
    public string Sku { get; set; }
}
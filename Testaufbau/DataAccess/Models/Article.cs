using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
public class Article
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public ArticleCategory ArticleCategory { get; set; }

    [ProtoMember(4)]
    public string? Description { get; set; }

    [ProtoMember(5)]
    public decimal Price { get; set; }

    [ProtoMember(6)]
    public string Sku { get; set; }
}
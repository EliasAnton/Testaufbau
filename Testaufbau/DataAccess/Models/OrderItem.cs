using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
//[ProtoInclude(3, typeof(Order))]
[ProtoInclude(5, typeof(Article))]
public class OrderItem
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ForeignKey(nameof(Order))]
    [ProtoMember(2)]
    public int OrderId { get; set; }

    //TODO: Dieses Attribut sorgt beim Abfragen von Order.OrderItems für eine zirkuläre Abhängigkeit (nicht von grpc-net unterstützt :( )
    [ProtoIgnore]
    public Order? Order { get; set; }

    [ProtoMember(3)]
    public int ArticleSku { get; set; }

    [ProtoMember(4)]
    public int Quantity { get; set; }

    //wenn ich es hier hinzufüge muss es auch in die DB mit null, da ich es sonst später nicht mit Werten füllen kann
    //Beim zusammenfügen mit den Artikeln würde ich sie gerne hier anfügen.
    //[ProtoMember(5)] public int? ArticleId { get; set; }
    [NotMapped]
    [ProtoIgnore]
    public Article? Article { get; set; }
}
using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
public class Price
{
    [Key]
    [ProtoMember(1)]
    public int Id { get; set; }
    
    [ProtoMember(2)]
    public decimal Amount { get; set; }
    
    [ProtoMember(3)]
    public string Currency { get; set; }
    
    [ProtoMember(4)]
    public string Country { get; set; }
    
}
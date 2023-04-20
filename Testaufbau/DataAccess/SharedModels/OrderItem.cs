using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testaufbau.DataAccess.SharedModels;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    public Order? Order { get; set; }

    [ForeignKey(nameof(Article))]
    public int ArticleId { get; set; }

    public Article? Article { get; set; }

    public int Quantity { get; set; }
}
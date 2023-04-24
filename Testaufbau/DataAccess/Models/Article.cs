using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Testaufbau.DataAccess.Models;

//[JsonSerializable(typeof(Article))]
public class Article
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public ArticleCategory ArticleCategory { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Sku { get; set; }
}
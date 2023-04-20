using System.ComponentModel.DataAnnotations;

namespace Testaufbau.DataAccess.Models;

public class Article
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public ArticleCategory ArticleCategory { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string SKU { get; set; }
}
namespace Testaufbau.Models;

public class Article
{
    public int ArticleId { get; set; }
    public string Name { get; set; }
    public ArticleCategory ArticleCategory { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string SKU { get; set; }
}
namespace News_Management.Domain.Entities;

public class News
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string? Slug { get; set; }
    public string? Images { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Content { get; set; } = null!;

    public List<MenuNews> MenuNews { get; set; } = new();
}
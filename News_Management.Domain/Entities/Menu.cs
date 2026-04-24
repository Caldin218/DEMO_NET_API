
namespace News_Management.Domain.Entities;

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string? Slug { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<MenuNews> MenuNews { get; set; } = new();
}
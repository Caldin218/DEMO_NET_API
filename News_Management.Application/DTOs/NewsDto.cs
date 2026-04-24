namespace News_Management.Application.DTOs
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<string> Menus { get; set; } = new();
    }
}
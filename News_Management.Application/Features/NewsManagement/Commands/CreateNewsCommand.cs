using MediatR;

namespace News_Management.Application.Features.NewsManagement.Commands
{
    public class CreateNewsCommand : IRequest<int>
    {
        public string Title { get; set; } = null!;
        public List<int> MenuIds { get; set; } = new();
        public string? Slug { get; set; }
        public string Content { get; set; } = null!;
    }
}
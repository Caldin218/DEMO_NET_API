using MediatR;

namespace News_Management.Application.Features.NewsManagement.Commands
{
    public class UpdateNewsCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<int> MenuIds { get; set; } = new();
    }
}
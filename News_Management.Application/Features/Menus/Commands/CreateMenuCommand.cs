using MediatR;

namespace News_Management.Application.Features.Menus.Commands
{
    public class CreateMenuCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
        public string? Slug { get; set; }
    }
}
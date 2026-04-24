using MediatR;

namespace News_Management.Application.Features.Menus.Commands
{
    public class UpdateMenuCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
using MediatR;

namespace News_Management.Application.Features.Menus.Commands
{
    public class DeleteMenuCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
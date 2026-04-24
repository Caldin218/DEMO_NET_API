using MediatR;

namespace News_Management.Application.Features.NewsManagement.Commands
{
    public class DeleteNewsCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
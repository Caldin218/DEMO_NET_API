using MediatR;
using News_Management.Application.Interfaces;
using News_Management.Domain.Entities;

namespace News_Management.Application.Features.Menus.Commands
{
    public class CreateMenuHandler : IRequestHandler<CreateMenuCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMenuHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = new Menu
            {
                Name = request.Name,
                Slug = request.Slug,
                CreatedAt = DateTime.UtcNow
            };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);

            return menu.Id;
        }
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.Interfaces;

namespace News_Management.Application.Features.Menus.Commands
{
    public class DeleteMenuHandler : IRequestHandler<DeleteMenuCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (menu == null)
                return false;

            menu.IsDeleted = true;
            menu.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
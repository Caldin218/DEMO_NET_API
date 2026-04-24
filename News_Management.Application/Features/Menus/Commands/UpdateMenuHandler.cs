using MediatR;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.Interfaces;

namespace News_Management.Application.Features.Menus.Commands
{
    public class UpdateMenuHandler : IRequestHandler<UpdateMenuCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMenuHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (menu == null)
                return false;

            menu.Name = request.Name;
            menu.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
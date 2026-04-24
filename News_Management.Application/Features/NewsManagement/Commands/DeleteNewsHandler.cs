using MediatR;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.Interfaces;

namespace News_Management.Application.Features.NewsManagement.Commands
{
    public class DeleteNewsHandler : IRequestHandler<DeleteNewsCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNewsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News
                .Include(x => x.MenuNews)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (news == null)
                return false;

            // soft delete
            news.IsDeleted = true;
            news.UpdatedAt = DateTime.UtcNow;

            _context.MenuNews.RemoveRange(news.MenuNews);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
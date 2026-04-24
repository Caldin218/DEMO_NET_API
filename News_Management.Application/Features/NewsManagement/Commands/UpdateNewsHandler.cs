using MediatR;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.Interfaces;
using News_Management.Domain.Entities;

namespace News_Management.Application.Features.NewsManagement.Commands
{
    public class UpdateNewsHandler : IRequestHandler<UpdateNewsCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateNewsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News
                .Include(x => x.MenuNews)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (news == null)
                return false;

            // update field
            news.Title = request.Title;
            news.UpdatedAt = DateTime.UtcNow;

            // 🔥 remove old relations
            _context.MenuNews.RemoveRange(news.MenuNews);

            // 🔥 add new relations
            foreach (var menuId in request.MenuIds.Distinct())
            {
                news.MenuNews.Add(new MenuNews
                {
                    MenuId = menuId,
                    NewsId = news.Id
                });
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
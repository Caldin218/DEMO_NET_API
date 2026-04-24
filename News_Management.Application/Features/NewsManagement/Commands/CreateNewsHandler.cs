using MediatR;
using News_Management.Application.Interfaces;
using News_Management.Domain.Entities;

namespace News_Management.Application.Features.NewsManagement.Commands
{
    public class CreateNewsHandler : IRequestHandler<CreateNewsCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateNewsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new News
            {
                Title = request.Title,
                Content = request.Content,
                Slug = request.Slug,
                CreatedAt = DateTime.UtcNow
            };

            foreach (var menuId in request.MenuIds.Distinct())
            {
                news.MenuNews.Add(new MenuNews
                {
                    MenuId = menuId
                });
            }

            _context.News.Add(news);
            await _context.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}
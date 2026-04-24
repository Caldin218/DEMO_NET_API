using MediatR;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.DTOs;
using News_Management.Application.Interfaces;

namespace News_Management.Application.Features.NewsManagement.Queries
{
    public class GetAllNewsHandler : IRequestHandler<GetAllNewsQuery, List<NewsDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNewsHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NewsDto>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.News
                .Where(x => x.IsDeleted != true)
                .Include(x => x.MenuNews)
                    .ThenInclude(x => x.Menu)
                .Select(x => new NewsDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Menus = x.MenuNews.Select(m => m.Menu.Name).ToList()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
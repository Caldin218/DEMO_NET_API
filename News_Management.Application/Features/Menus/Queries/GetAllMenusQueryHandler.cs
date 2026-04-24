using MediatR;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.DTOs;
using News_Management.Application.Interfaces;

namespace News_Management.Application.Features.Menus.Queries
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, List<MenuDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMenusQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDto>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            return await _context.Menus
                .Where(x => x.IsDeleted != true)
                .Select(x => new MenuDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}
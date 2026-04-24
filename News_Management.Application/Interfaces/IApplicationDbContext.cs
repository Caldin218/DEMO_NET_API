using Microsoft.EntityFrameworkCore;
using News_Management.Domain.Entities;

namespace News_Management.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Menu> Menus { get; set; }
        DbSet<News> News { get; set; }
        DbSet<MenuNews> MenuNews { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
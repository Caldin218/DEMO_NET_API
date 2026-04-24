using MediatR;
using News_Management.Application.DTOs;

namespace News_Management.Application.Features.Menus.Queries
{
    public class GetAllMenusQuery : IRequest<List<MenuDto>>
    {
    }
}
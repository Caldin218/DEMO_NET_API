using MediatR;
using News_Management.Application.DTOs;

namespace News_Management.Application.Features.NewsManagement.Queries
{
    public class GetAllNewsQuery : IRequest<List<NewsDto>>
    {
    }
}
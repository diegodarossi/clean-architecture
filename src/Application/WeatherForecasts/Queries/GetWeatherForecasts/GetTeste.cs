using System.Collections.Generic;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public record GetTesteQuery : IRequest<IQueryable<GetTesteDto>>
{
}

public class GetTesteHandler : IRequestHandler<GetTesteQuery, IQueryable<GetTesteDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTesteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<GetTesteDto>> Handle(GetTesteQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_context.TodoItems.AsQueryable().Select(f => new GetTesteDto() 
        {
            ListId = f.ListId,
            Title = f.Title,
            Note = f.Note,
            Priority = f.Priority,
            Created = f.Created
        }).AsQueryable());
    }
}

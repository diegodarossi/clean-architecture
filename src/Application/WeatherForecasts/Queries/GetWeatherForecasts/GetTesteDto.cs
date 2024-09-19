using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public class GetTesteDto
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTimeOffset Created { get; set; }
}

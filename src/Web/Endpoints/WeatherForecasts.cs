using CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CleanArchitecture.Web.Endpoints;

public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetWeatherForecasts)
            .MapPost(GetTeste, "teste");
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }

    public async Task<DataSourceResult> GetTeste(ISender sender, DataSourceRequestState request)
    {
        var teste = new GetTesteQuery();
        var resultado = await sender.Send(teste);
        return resultado.ToDataSourceResult(request);
    }
}

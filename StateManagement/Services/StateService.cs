using System.Net.Http.Json;

namespace StateManagement.Services;

public class StateService
{
    private readonly HttpClient _httpClient;

    public WeatherForecast[]? Forecasts { get; private set; }
    public int ForecastAmount => Forecasts?.Length ?? 0;

    public event Action? OnChange;

    public StateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task InitializeAsync()
    {
        Forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        OnChange?.Invoke();
    }

    public void Clear()
    {
        Forecasts = null;
        OnChange?.Invoke();
    }
}

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

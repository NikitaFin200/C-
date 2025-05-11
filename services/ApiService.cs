public class ApiService
{
    private readonly HttpClient _client = new HttpClient();

    public ApiService()
    {
        _client.DefaultRequestHeaders.Add("X-API-KEY", "7d3e436f-f59c-46dd-989d-dac71211f263");
    }

    public async Task<List<Film>> GetTopFilmsAsync()
    {
        var response = await _client.GetStringAsync("https://kinopoiskapiunofficial.tech/api/v2.2/films/top?type=TOP_100_POPULAR_FILMS&page=1");
        var json = JsonDocument.Parse(response);
        return json.RootElement.GetProperty("films").EnumerateArray().Select(f => new Film
        {
            KinopoiskId = f.GetProperty("filmId").GetInt32(),
            NameRu = f.GetProperty("nameRu").GetString(),
            Year = f.GetProperty("year").GetString(),
            PosterUrlPreview = f.GetProperty("posterUrlPreview").GetString()
        }).ToList();
    }

    public async Task<Film> GetFilmDetailsAsync(int id)
    {
        var response = await _client.GetStringAsync($"https://kinopoiskapiunofficial.tech/api/v2.2/films/{id}");
        var json = JsonDocument.Parse(response);
        var root = json.RootElement;
        return new Film
        {
            KinopoiskId = root.GetProperty("kinopoiskId").GetInt32(),
            NameRu = root.GetProperty("nameRu").GetString(),
            Year = root.GetProperty("year").GetString(),
            Description = root.GetProperty("description").GetString(),
            PosterUrlPreview = root.GetProperty("posterUrlPreview").GetString()
        };
    }
}
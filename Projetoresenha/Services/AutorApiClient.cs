using System.Net.Http;
using System.Net.Http.Json;

public class AutorApiClient
{
    private readonly HttpClient _http;

    public AutorApiClient(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient("ApiResenha");
    }

    public async Task<List<AutorDto>> GetAutoresAsync()
    {
        var result = await _http.GetFromJsonAsync<List<AutorDto>>("api/Autor");
        return result ?? new List<AutorDto>();
    }
}

public class AutorDto
{
    public int Pkid_autor { get; set; }
    public string Nome { get; set; }
    public string Nacionalidade { get; set; }
    public DateTime Data_nascimento { get; set; }
}

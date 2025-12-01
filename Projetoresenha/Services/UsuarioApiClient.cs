using System.Net.Http;
using System.Net.Http.Json;

namespace Projetoresenha.Services
{
    public class UsuarioDto
    {
        public int Pkid_usuario { get; set; }     
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class UsuarioApiClient
    {
        private readonly HttpClient _http;

        public UsuarioApiClient(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("ApiResenha");
        }

        public async Task<bool> RegistrarAsync(UsuarioDto dto)
        {
            var resp = await _http.PostAsJsonAsync("api/Usuario", dto);
            return resp.IsSuccessStatusCode;
        }
    }
}

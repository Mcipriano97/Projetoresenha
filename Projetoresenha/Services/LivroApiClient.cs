using System.Net.Http.Json;
using Projetoresenha.Models;

namespace Projetoresenha.Services
{
    public class LivroApiClient
    {
        private readonly HttpClient _client;

        public LivroApiClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("ApiResenha");
        }

        public async Task<LivroDetalhesViewModel?> ObterDetalhesAsync(int id)
        {
            return await _client.GetFromJsonAsync<LivroDetalhesViewModel>($"api/livro/{id}");
        }

        public async Task<bool> EnviarResenhaAsync(int livroId, string comentario, int nota)
        {
            // aqui estou mandando UsuarioId fixo 1 por enquanto
            var response = await _client.PostAsJsonAsync("api/resenha", new
            {
                livroId = livroId,
                usuarioId = 1,
                comentario = comentario,
                nota = nota
            });

            return response.IsSuccessStatusCode;
        }
    }
}

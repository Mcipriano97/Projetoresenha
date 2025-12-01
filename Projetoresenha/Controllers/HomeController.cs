using Microsoft.AspNetCore.Mvc;
using Projetoresenha.Models;
using System.Net.Http.Json;

namespace Projetoresenha.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            // "ApiResenha" é o nome configurado no Program.cs
            _httpClient = httpClientFactory.CreateClient("ApiResenha");
        }

        // HOME / INDEX – página principal
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // LOGIN (GET) – mostra a tela de login
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // LOGIN (POST) – recebe o form e chama a API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/usuario/login", new
            {
                email = model.Email,
                senha = model.Senha
            });

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        // CADASTRO (GET) – mostra o formulário
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View(new CadastroViewModel());
        }

        // CADASTRO (POST) – envia para a API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(CadastroViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/usuario/cadastro", new
            {
                nome = model.Nome,
                sobrenome = model.Sobrenome,
                email = model.Email,
                senha = model.Senha
            });

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Erro ao cadastrar o usuário.");
                return View(model);
            }

            
            return RedirectToAction("Login", "Home");
        }
    }
}

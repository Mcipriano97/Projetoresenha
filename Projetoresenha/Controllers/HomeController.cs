using Microsoft.AspNetCore.Mvc;
using Projetoresenha.Models;

namespace Projetoresenha.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Livros() => View();

        public IActionResult LivroDetalhes(int id) => View(); // depois podemos trocar por um ViewModel

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: autenticar usuário (Identity, etc.)
            // if falhar: ModelState.AddModelError("", "Credenciais inválidas"); return View(model);

            return RedirectToAction("Livros");
        }

        [HttpGet]
        public IActionResult Cadastro() => View(new CadastroViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(CadastroViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: persistir usuário e hash de senha
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PublicarResenha(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Você pode repassar o model de volta para a página de detalhes
                TempData["ReviewErrors"] = "Revise os campos da sua resenha.";
                return RedirectToAction("LivroDetalhes", new { id = model.LivroId });
            }

            // TODO: salvar resenha (LivroId, Nota, Texto, Usuario, Data)
            return RedirectToAction("LivroDetalhes", new { id = model.LivroId });
        }

        public IActionResult Sobre() => View();
        public IActionResult Privacy() => View();
    }
}

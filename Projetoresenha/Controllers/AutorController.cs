using Microsoft.AspNetCore.Mvc;

public class AutorController : Controller
{
    private readonly AutorApiClient _api;

    public AutorController(AutorApiClient api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var autores = await _api.GetAutoresAsync();
        return View(autores);
    }
}

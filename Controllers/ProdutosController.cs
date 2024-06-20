using Microsoft.AspNetCore.Mvc;

namespace InnovaAgroTech.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

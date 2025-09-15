using Microsoft.AspNetCore.Mvc;

namespace LojaBrinquedos.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

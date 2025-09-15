using Microsoft.AspNetCore.Mvc;

namespace LojaBrinquedos.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

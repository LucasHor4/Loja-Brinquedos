using LojaBrinquedos.Models;
using LojaBrinquedos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Diagnostics;

namespace LojaBrinquedos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoRepositorio _produtoRepositorio;

        //⬇⬇⬇ usado para registrar logs da aplicação(mensagens de erro, avisos, etc).
        public HomeController(ILogger<HomeController> logger, ProdutoRepositorio produtoRepositorio)
        {
            _logger = logger;
            _produtoRepositorio = produtoRepositorio; //classe que acessa os produtos
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepositorio.TodosProdutos(); //Chama do repositório, que retorna (de forma assíncrona) todos os produtos da loja.
            return View(produtos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
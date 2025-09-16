using LojaBrinquedos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LojaBrinquedos.Controllers
{
    public class CarrinhoController : Controller
    {
        // injeção de dependências ⬇⬇
        private readonly CarrinhoRepositorio _carrinhoRepositorio; //gerencia as operações no carrinho
        private readonly ProdutoRepositorio _produtoRepositorio; //busca informações dos produtos no banco de dados.

        public CarrinhoController(CarrinhoRepositorio carrinhoRepositorio, ProdutoRepositorio produtoRepositorio)
        {
            _carrinhoRepositorio = carrinhoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }
        public async Task<IActionResult> Index()
        {
            var cartItems = _carrinhoRepositorio.CarrinhoItems(HttpContext.Session); 
            //⬆⬆Pega os itens do carrinho que estão na sessão do usuário
            // Iterar sobre os itens do carrinho e buscar os detalhes do produto
            foreach (var item in cartItems) //Para cada item, busca os detalhes do produto no banco
            {
                // Certifique-se de que _productRepository está retornando um Product ou null
                item.Produto = await _produtoRepositorio.ProdutosPorId(item.ProdutoId);

                // Opcional: Lógica para lidar com produtos que não foram encontrados (removidos do DB, etc.)
                if (item.Produto == null)
                {
                    // Poderia remover o item do carrinho ou marcá-lo como indisponível
                    // Exemplo: item.Product = new Product { Name = "Produto Indisponível", Price = 0, ImageUrl = "/images/default_unavailable.jpg" };
                }
            }
            ViewBag.TotalCarrinho = _carrinhoRepositorio.TotalCarrinho(HttpContext.Session);
            return View(cartItems);
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarCarrinho(int produtoId, int quantidade = 1)
        {
            var produto = await _produtoRepositorio.ProdutosPorId(produtoId);
            if (produto == null)
            {
                TempData["Message"] = "Produto não encontrado."; // Use TempData para mensagens
                return RedirectToAction("Index", "Home");
            }
            //⬆⬆Busca o produto no banco; se não achar, mostra uma mensagem (TempData) e volta para a Home.

            _carrinhoRepositorio.AdicionarCarrinho(HttpContext.Session, produto, quantidade);
            return RedirectToAction("Index", "Carrinho");
            //Se existir, adiciona ao carrinho e redireciona para a página do carrinho.⬆⬆
        }

        [HttpPost]
        public IActionResult AlterarQuantidadeItem(int produtoId, int novaQuantidade)
        {
            _carrinhoRepositorio.AlterarQuantidadeItem(HttpContext.Session, produtoId, novaQuantidade);
            return RedirectToAction("Index");
        } 
        //⬆⬆Era para isso alterar a quantidade, mas no meu (esse) não vai, ele só pisca a tela (ao menos no meu pc). 

        [HttpPost]
        public IActionResult RemoveFromCart(int produtoId)
        {
            _carrinhoRepositorio.RemoverItemCarrinho(HttpContext.Session, produtoId);
            return RedirectToAction("Index");
        }
        //remove um item do carrinho⬆⬆

        [HttpPost]
        public IActionResult LimparCarrinho()
        {
            _carrinhoRepositorio.LimparCarrinho(HttpContext.Session);
            return RedirectToAction("Index");
        }
        //limpa o carrinho ⬆⬆
    }
}
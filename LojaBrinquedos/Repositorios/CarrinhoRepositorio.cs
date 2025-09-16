using LojaBrinquedos.Models;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;


namespace LojaBrinquedos.Repositorio
{
    public class CarrinhoRepositorio
    {
        private const string CartSessionKey = "Carrinho";
        //⬆⬆ chave usada para guardar os dados do carrinho na sessão (HttpContext.Session).

        public List<ItemCarrinho> CarrinhoItems(ISession session)
        {
            var cartJson = session.GetString(CartSessionKey);
            return cartJson == null ? new List<ItemCarrinho>() : JsonConvert.DeserializeObject<List<ItemCarrinho>>(cartJson);
        }
        //⬆⬆ Busca os itens do carrinho na sessão (em formato JSON).
        // Se não existir carrinho ainda → retorna lista vazia.
        //Se existir → desserializa o JSON em uma lista de ItemCarrinho.

        public void AdicionarCarrinho(ISession session, Produto produto, int quantidade)
        {
            var cart = CarrinhoItems(session);
            var existingItem = cart.FirstOrDefault(item => item.ProdutoId == produto.Id);

            if (existingItem != null) //verifica se o produto já está no carrinho
            {
                existingItem.Quantidade += quantidade; 
                //Se sim → aumenta a quantidade.
            }
            else
            {
                cart.Add(new ItemCarrinho
                {
                    ProdutoId = produto.Id,
                    //Produto = produto,
                    Quantidade = quantidade,
                    Preco = produto.Preco
                });
                //Se não → cria um novo ItemCarrinho.
            }
            SalvarCarrinho(session, cart);
            // No final chama isso⬆ para gravar a nova lista na sessão.
        }

        public void AlterarQuantidadeItem(ISession session, int produtoId, int novaQuantidade)
            //Isession guarda dados do usuario (cache)
        {
            var cart = CarrinhoItems(session);
            var itemAlterar = cart.FirstOrDefault(item => item.ProdutoId == produtoId);

            if (itemAlterar != null)
            {
                if (novaQuantidade <= 0)
                {
                    cart.Remove(itemAlterar);
                }
                else
                {
                    itemAlterar.Quantidade = novaQuantidade;
                }
                SalvarCarrinho(session, cart);
            }
        }

        public void RemoverItemCarrinho(ISession session, int produtoId)
        {
            var cart = CarrinhoItems(session);
            var itemRemover = cart.FirstOrDefault(item => item.ProdutoId == produtoId);
            if (itemRemover != null)
            {
                cart.Remove(itemRemover);
                SalvarCarrinho(session, cart);
            }
        }

        public void LimparCarrinho(ISession session)
        {
            session.Remove(CartSessionKey);
        }

        public decimal TotalCarrinho(ISession session)
        {
            return CarrinhoItems(session).Sum(item => item.Total);
        }

        private void SalvarCarrinho(ISession session, List<ItemCarrinho> cart)
        {
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
        }
    }
}
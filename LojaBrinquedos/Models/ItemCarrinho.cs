namespace LojaBrinquedos.Models
{
    public class ItemCarrinho
        //criando a classe carrinho (deve ser igual ao do banco de dados)
    {
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Total => Quantidade * Preco;
    }
}
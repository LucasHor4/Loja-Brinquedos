namespace LojaBrinquedos.Models
{
    public class ItemCarrinho
    {
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Total => Quantidade * Preco;
    }
}
using Dapper;
using LojaBrinquedos.Models;
using MySql.Data.MySqlClient;


namespace LojaBrinquedos.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString; // string de conexão
        //contém as informações para se conectar ao banco

        public ProdutoRepositorio(string connectionString) //classe responsável por acessar os dados de produtos
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Produto>> TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString); //Abre uma conexão com o MySQL (MySqlConnection).
            var sql = "SELECT Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM produto";
            return await connection.QueryAsync<Produto>(sql);
            //⬆⬆ Usa Dapper.QueryAsync<Produto>() e executa o SQL e mapeia automaticamente os resultados para objetos da classe Produto.
        }


        public async Task<Produto?> ProdutosPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM produto WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
            //⬆⬆ Retorna o primeiro resultado se encontrar, retorna null se não encontrar (por isso o retorno é Produto?).
        }


    }


}
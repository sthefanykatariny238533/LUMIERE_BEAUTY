using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;

namespace Lumiere_Beauty.DAO
{
    public class CategoriaDAO
    {
        private readonly Conexao _conexao;

        // A Conexao é injetada pelo container de dependências
        public CategoriaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // READ — lista todas as categorias
        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();

            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM Categoria;";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(MapearCategoria(leitor));
            }

            return lista;
        }

        // Método auxiliar para transformar uma linha
        // do banco em um objeto Categoria
        private static Categoria MapearCategoria(
            System.Data.Common.DbDataReader leitor)
        {
            return new Categoria
            {
                Id = leitor.GetInt32(
                    leitor.GetOrdinal("id_categoria")
                ),

                Nome = leitor.IsDBNull(
                    leitor.GetOrdinal("nome_catego")
                )
                    ? string.Empty
                    : leitor.GetString(
                        leitor.GetOrdinal("nome_catego")
                    )
            };
        }

        // CREATE — cadastra uma nova categoria
        public void Inserir(Categoria categoria)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"
                    INSERT INTO Categoria
                    (nome_catego)
                    VALUES
                    (@nome)";

                using var comando = con.CreateCommand();

                comando.CommandText = sql;

                comando.Parameters.AddWithValue(
                    "@nome",
                    categoria.Nome
                );

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
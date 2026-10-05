using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;

namespace Lumiere_Beauty.DAO
{
    public class CategoriaDAO
    {
        private readonly Conexao _conexao;

        public CategoriaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Categoria> Listar()
        {
            try
            {
                var lista = new List<Categoria>();

                // Buscando e abrindo a conexão com o banco de dados
                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Categoria";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var categoria = new Categoria();

                    categoria.Id = leitor.GetInt32("id_categoria");
                    categoria.Nome = leitor.GetString("nome_catego");

                    lista.Add(categoria);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public void Inserir(Categoria categoria)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"INSERT INTO Categoria (nome_catego)
                    VALUES (@nome)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@nome", categoria.Nome);
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
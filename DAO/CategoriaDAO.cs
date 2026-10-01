using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;
using MySql.Data.MySqlClient;

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

                using var con = _conexao.GetConnection();

                string sql = "SELECT * from Categoria;";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var categoria = new Categoria();

                    categoria.Id = leitor.GetInt32("id_categoria");

                    if (!leitor.IsDBNull(leitor.GetOrdinal("nome_catego")))
                    {
                        categoria.Nome = leitor.GetString("nome_catego");
                    }

                    lista.Add(categoria);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}
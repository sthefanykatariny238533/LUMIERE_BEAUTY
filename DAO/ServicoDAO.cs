using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;

namespace Lumiere_Beauty.DAO
{
    public class ServicoDAO
    {
        private readonly Conexao _conexao;

        public ServicoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Servico> Listar()
        {
            try
            {
                var lista = new List<Servico>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Servico";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var servico = new Servico();

                    servico.Id = leitor.GetInt32("id_servico");
                    servico.Nome = leitor.GetString("nome_serv");
                    servico.Descricao = leitor.GetString("descricao");
                    servico.Preco = leitor.GetDouble("preco");
                    servico.IdCategoria = leitor.GetInt32("id_categoria_fk");

                    lista.Add(servico);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public void Inserir(Servico servico)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"
                    INSERT INTO Servico
                    (nome_serv, descricao, preco, id_categoria_fk)
                    VALUES
                    (@nome, @descricao, @preco, @idCategoria)";

                using var comando = con.CreateCommand();

                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@nome", servico.Nome);
                comando.Parameters.AddWithValue("@descricao", servico.Descricao);
                comando.Parameters.AddWithValue("@preco", servico.Preco);
                comando.Parameters.AddWithValue("@idCategoria", servico.IdCategoria);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
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

                // Buscando e abrindo a conexão com o banco de dados
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
    }
}

using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;

namespace Lumiere_Beauty.DAO
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> Listar()
        {
            try
            {
                var lista = new List<Cliente>();

                // Buscando e abrindo a Conexão com o banco de dados
                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM Cliente";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var cliente = new Cliente();

                    cliente.Id = leitor.GetInt32("id_cliente");
                    cliente.NomeCompleto = leitor.GetString("nome_completo_cli");
                    cliente.Email = leitor.GetString("email_cli");
                    cliente.Senha = leitor.GetString("senha_cli");

                    lista.Add(cliente);
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
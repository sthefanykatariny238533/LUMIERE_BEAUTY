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

        public void Inserir(Cliente cliente)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"INSERT INTO Cliente
                    (nome_completo_cli, email_cli, senha_cli)
                    VALUES
                    (@nome, @email, @senha)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@nome", cliente.NomeCompleto);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@senha", cliente.Senha);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}

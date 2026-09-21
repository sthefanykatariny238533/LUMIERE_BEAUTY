using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;
using MySql.Data.MySqlClient;

namespace Lumiere_Beauty.DAO
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        // A Conexao é injetada pelo container de dependências
        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // READ — lista todos os clientes
        public List<Cliente> Listar()
        {
            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM Cliente;");

            var leitor = (MySqlDataReader)comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(MapearCliente(leitor));
            }

            return lista;
        }

        // Método auxiliar: converte a linha atual do leitor em um objeto Cliente.
        // Usa o DAOHelper para ler com segurança as colunas que podem ser NULL.
        private static Cliente MapearCliente(MySqlDataReader leitor)
        {
            return new Cliente
            {
                Id = leitor.GetInt32("id_cliente"),

                NomeCompleto = DAOHelper.GetString(
                    leitor,
                    "nome_completo_cli"
                ),

                Email = DAOHelper.GetString(
                    leitor,
                    "email_cli"
                ),

                Senha = DAOHelper.GetString(
                    leitor,
                    "senha_cli"
                )
            };
        }
    }
}
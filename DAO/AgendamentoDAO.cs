using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;
using MySql.Data.MySqlClient;

namespace Lumiere_Beauty.DAO
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao;

        // A Conexao é injetada pelo container de dependências

        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }


        // READ - lista todos os processos
        public List<Agendamento> Listar()
        {
            var lista = new List<Agendamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM agendamento;");

            var leitor = (MySqlDataReader)comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(MapearAgendamento(leitor));
            }
            return lista;
        }


        // Método auxiliar: converte a linha atual do leitor em um objeto Processo
        // Usa o DAOHelper para ler com segurança as colunas que podem ser NULL
        private static Agendamento MapearAgendamento(MySqlDataReader leitor)
        {
            return new Agendamento
            {
                id = leitor.GetInt32("id"),

                data = leitor.GetDateTime("data"),

                horario = TimeOnly.FromTimeSpan(leitor.GetTimeSpan("horario")),

                status = leitor.GetString("status"),

                id_servico_fk = leitor.GetInt32("id_servico_fk"),

                id_profissional_fk = leitor.GetInt32("id_profissional_fk"),

                id_cliente_fk = leitor.GetInt32("id_cliente_fk")

            };
        }





    }
}

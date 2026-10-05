using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;
using MySql.Data.MySqlClient;

namespace Lumiere_Beauty.DAO
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao;

        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Agendamento> Listar()
        {
            try
            {
                var lista = new List<Agendamento>();

                using var con = _conexao.GetConnection();

                string sql = @"
                SELECT 
                    id_agend,
                    data_agend,
                    horario_agend,
                    status_agend,
                    id_cliente_fk,
                    id_profissional_fk,
                    id_servico_fk
                FROM Agendamento;
            ";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var agendamento = new Agendamento();

                    agendamento.id = leitor.GetInt32("id_agend");
                    agendamento.data =  DateOnly.FromDateTime(leitor.GetDateTime("data_agend"));
                    agendamento.horario = TimeOnly.FromTimeSpan(leitor.GetTimeSpan("horario_agend"));
                    agendamento.status = leitor.GetString("status_agend");
                    agendamento.id_cliente_fk = leitor.GetInt32("id_cliente_fk");
                    agendamento.id_profissional_fk = leitor.GetInt32("id_profissional_fk");
                    agendamento.id_servico_fk = leitor.GetInt32("id_servico_fk");

                    lista.Add(agendamento);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }
   

    public void Agendamento(Agendamento agendamento)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"INSERT INTO agendamento (id_agend, data_agend, horario_agend, status_agend, 
                             id_cliente_fk, id_profissional_fk, id_servico_fk) VALUES (@id, @data, @horario,
                             @status, @id_cliente, @id_profissional, @id_servico)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@id", agendamento.id);

                comando.Parameters.AddWithValue("@data", agendamento.data!.Value.ToDateTime(TimeOnly.MinValue));

                comando.Parameters.AddWithValue("@horario", agendamento.horario);

                comando.Parameters.AddWithValue("@status", agendamento.status);

                comando.Parameters.AddWithValue("@id_cliente", agendamento.id_cliente_fk);

                comando.Parameters.AddWithValue("@id_profissional", agendamento.id_profissional_fk);

                comando.Parameters.AddWithValue("@id_servico", agendamento.id_servico_fk);

                comando.ExecuteNonQuery();
            } catch { throw; }
        }


    }
}
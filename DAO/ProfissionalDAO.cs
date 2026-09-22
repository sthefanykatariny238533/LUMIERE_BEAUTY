using Lumiere_Beauty.Configs;
using Lumiere_Beauty.Models;
using MySql.Data.MySqlClient;

namespace Lumiere_Beauty.DAO
{
    public class ProfissionalDAO
    {
        private readonly Conexao _conexao;

        public ProfissionalDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Profissional> Listar()
        {
            try
            {
                var lista = new List<Profissional>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * from Profissional;";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var profissional = new Profissional();

                    profissional.Id = leitor.GetInt32("id_profissional");
                    profissional.Nome = leitor.GetString("nome_profi");

                    if (!leitor.IsDBNull(leitor.GetOrdinal("telefone_profi")))
                    {
                        profissional.Telefone = leitor.GetString("telefone_profi");
                    }

                    if (!leitor.IsDBNull(leitor.GetOrdinal("especialidade_profi")))
                    {
                        profissional.Especialidade = leitor.GetString("especialidade_profi");
                    }

                    lista.Add(profissional);
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

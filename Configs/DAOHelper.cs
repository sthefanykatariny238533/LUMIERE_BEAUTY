using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace Lumiere_Beauty.Configs
{
    public static class DAOHelper
    {
        // Lê uma string; se a coluna for NULL, devolve string vazia
        public static string GetStrin(MySqlDataReader reader, string column_name)
        {
            string text = string.Empty;
            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                text = reader.GetString(column_name);
            return text;
        }


        // Lê um double; se a coluna for NULL, devolve 0.0
        public static double GetDouble(MySqlDataReader reader, string column_name)
        {
            double value = 0.0;
            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                value = reader.GetDouble(column_name);
            return value;
        }


        // Lê uma data; se a coluna for NULL, devolve null
        public static DateTime? GetDateTime(MySqlDataReader reader, string column_name)
        {
            DateTime? Value = null;
            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                Value = reader.GetDateTime(column_name);
            return Value;
        }


        // Indica se uma coluna está NULL
        public static bool IsNull(MySqlDataReader reader, string column_name)
        {
            return reader.IsDBNull(reader.GetOrdinal(column_name));
        }



    }
}

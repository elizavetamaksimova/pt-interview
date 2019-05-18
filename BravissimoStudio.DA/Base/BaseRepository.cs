using System.Configuration;
using System.Data.SqlClient;

namespace BravissimoStudio.DA
{
    public abstract class BaseRepository
    {
        protected static string ConnectionString;

        protected delegate void ReadDelegate(SqlDataReader reader);

        static BaseRepository()
        {
            ConnectionString = GetConnectionString();
        }

        protected void Read(string query, ReadDelegate predicate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        predicate(reader);
                    }
                }

                reader.Close();
            }
        }

        protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}

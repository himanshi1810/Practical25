using Microsoft.Data.SqlClient;

namespace Employee.DAL.Services
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext()
        {
            _connectionString = "Server=SF-CPU-0226\\SQLEXPRESS;Database=Practical_25;Trusted_Connection=True;Encrypt=False;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

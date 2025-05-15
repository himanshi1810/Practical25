using Employee.DAL.Handlers.Commands;
using Employee.DAL.Services;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Employee.DAL.Handlers
{
    public class SoftDeleteEmployeeCommandHandler : IRequestHandler<SoftDeleteEmployeeCommand,bool>
    {
        private readonly DbContext _context;
        public SoftDeleteEmployeeCommandHandler(DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SoftDeleteEmployeeCommand emp, CancellationToken cancellationToken)
        {
            using (var conn = _context.GetConnection())
            {
                string query = "UPDATE Employee SET EmployeeStatus = 'Inactive' WHERE EmployeeId = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);

                    try
                    {
                        await conn.OpenAsync(cancellationToken);
                        int rowsAffected = await cmd.ExecuteNonQueryAsync(cancellationToken);
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
    }
}

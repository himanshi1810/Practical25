using Employee.DAL.Handlers.Queries;
using Employee.DAL.Models;
using Employee.DAL.Services;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Employee.DAL.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployee, IEnumerable<EmployeeModel>>
    {
        private readonly DbContext _context;
        public GetEmployeeHandler(DbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeModel>> Handle(GetEmployee request, CancellationToken cancellationToken)
        {
            var employees = new List<EmployeeModel>();

            string query = request.Id.HasValue
                ? "SELECT * FROM Employee WHERE EmployeeId = @Id"
                : "SELECT * FROM Employee";

            using (var conn = _context.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                if (request.Id.HasValue)
                    cmd.Parameters.AddWithValue("@Id", request.Id.Value);

                await conn.OpenAsync(cancellationToken);
                using (var reader = await cmd.ExecuteReaderAsync(cancellationToken))
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        employees.Add(new EmployeeModel
                        {
                            EmployeeId = (int)reader["EmployeeId"],
                            EmployeeName = reader["EmployeeName"].ToString(),
                            EmployeeSalary = (decimal)reader["EmployeeSalary"],
                            DepartmentId = (int)reader["DepartmentId"],
                            EmployeeEmail = reader["EmployeeEmail"].ToString(),
                            EmployeeJoiningDate = (DateTime)reader["EmployeeJoiningDate"],
                            EmployeeStatus = reader["EmployeeStatus"].ToString()
                        });
                    }
                }

            }

            return employees;
        }
    }
}

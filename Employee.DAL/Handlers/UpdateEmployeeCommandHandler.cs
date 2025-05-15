using Employee.DAL.Handlers.Commands;
using Employee.DAL.Services;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Employee.DAL.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly DbContext _context;
        public UpdateEmployeeCommandHandler(DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = request.Employee;
            using (var conn = _context.GetConnection())
            {
                await conn.OpenAsync(cancellationToken);
                string query = @"UPDATE Employee SET 
                                EmployeeName = @Name,
                                EmployeeSalary = @Salary,
                                DepartmentId = @DeptId,
                                EmployeeEmail = @Email
                                WHERE EmployeeId = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Salary", emp.EmployeeSalary);
                cmd.Parameters.AddWithValue("@DeptId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@Email", emp.EmployeeEmail);
                var result = await cmd.ExecuteNonQueryAsync(cancellationToken);
                return result > 0;
            }
        }
    }
}

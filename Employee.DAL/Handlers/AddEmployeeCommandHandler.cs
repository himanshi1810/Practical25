using Employee.DAL.Handlers.Commands;
using Employee.DAL.Services;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Employee.DAL.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, bool>
    {
        private readonly DbContext _context;

        public AddEmployeeCommandHandler(DbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.Employee;
            using (var connection = _context.GetConnection())
            {
                await connection.OpenAsync(cancellationToken);
                var command = new SqlCommand("INSERT INTO Employee (EmployeeName, EmployeeSalary, DepartmentId, EmployeeEmail, EmployeeJoiningDate, EmployeeStatus) VALUES (@name, @salary, @departmentId, @email, @joiningDate, 'Active')", connection);
                command.Parameters.AddWithValue("@name", employee.EmployeeName);
                command.Parameters.AddWithValue("@salary", employee.EmployeeSalary);
                command.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
                command.Parameters.AddWithValue("@email", employee.EmployeeEmail);
                command.Parameters.AddWithValue("@joiningDate", employee.EmployeeJoiningDate);
                var result = await command.ExecuteNonQueryAsync(cancellationToken);
                return result > 0;
            }
        }
    }
}

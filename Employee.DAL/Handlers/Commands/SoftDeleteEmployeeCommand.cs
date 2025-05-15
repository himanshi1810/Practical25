using MediatR;

namespace Employee.DAL.Handlers.Commands
{
    public class SoftDeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }
        public SoftDeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}

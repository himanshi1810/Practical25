using Employee.DAL.Models.DTOs;
using MediatR;

namespace Employee.DAL.Handlers.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public UpdateEmployeeDTO Employee { get; set; }
        public UpdateEmployeeCommand(UpdateEmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}

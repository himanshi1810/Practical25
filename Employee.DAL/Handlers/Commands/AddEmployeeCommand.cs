using Employee.DAL.Models.DTOs;
using MediatR;

namespace Employee.DAL.Handlers.Commands
{
    public class AddEmployeeCommand : IRequest<bool>
    {
        public AddEmployeeDTO Employee { get; set; }
        public AddEmployeeCommand(AddEmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}

using Employee.DAL.Models;
using MediatR;

namespace Employee.DAL.Handlers.Queries
{
    public class GetEmployee : IRequest<IEnumerable<EmployeeModel>>
    {
        public int? Id { get; set; }

        public GetEmployee(int? id = null)
        {
            Id = id;
        }
    }
}

using Employee.DAL.Models.DTOs;
using FluentValidation;

namespace Employee.DAL.FluentValidators
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeDTO>
    {
        public AddEmployeeValidator()
        {
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Employee Name is required.")
                .Length(2, 50).WithMessage("Employee Name must be between 2 and 50 characters.");
            RuleFor(x => x.EmployeeEmail)
                .NotEmpty().WithMessage("Employee Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.EmployeeSalary)
                .GreaterThan(0).WithMessage("Employee Salary must be greater than 0.");
            RuleFor(x => x.EmployeeJoiningDate)
                .NotEmpty().WithMessage("Employee Joining Date is required.")
                .LessThan(DateTime.Now).WithMessage("Employee Joining Date cannot be in the future.");
        }
    }
}

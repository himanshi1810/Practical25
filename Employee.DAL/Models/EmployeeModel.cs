namespace Employee.DAL.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int DepartmentId { get; set; }
        public string? EmployeeEmail { get; set; }
        public DateTime EmployeeJoiningDate { get; set; }
        public string? EmployeeStatus { get; set; }
    }
}

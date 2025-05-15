namespace Employee.DAL.Models.DTOs
{
    public class UpdateEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public string EmployeeEmail { get; set; }
        public int DepartmentId { get; set; }
        public DateTime EmployeeJoiningDate { get; set; }
    }
}

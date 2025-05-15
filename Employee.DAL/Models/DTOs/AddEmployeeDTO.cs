namespace Employee.DAL.Models.DTOs
{
    public class AddEmployeeDTO
    {
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeEmail { get; set; }
        public DateTime EmployeeJoiningDate { get; set; }
    }
}

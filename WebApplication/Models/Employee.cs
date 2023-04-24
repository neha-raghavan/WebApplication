using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplications.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
       
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public string? Department { get; set; }
    }
}

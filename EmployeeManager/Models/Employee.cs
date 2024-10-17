using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeManager.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(100,ErrorMessage ="First name characters cannot be more that 100 character")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }
    
        [Required(ErrorMessage = "Department is required")]
        [Department(new[] { "IT","HR" })]//Allowed departments
        [MaxLength(50, ErrorMessage ="Department name cannot be more than 50 characters")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]// Specifies that this is a date
        public DateTime? HireDate { get; set; }


    }
}

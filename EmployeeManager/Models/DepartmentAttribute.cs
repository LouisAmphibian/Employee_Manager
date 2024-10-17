
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Models
{
    /*
    an attribute can be used anywhere so to restrict that, developer can actually only use it on a method or a property or a class
    So in order to restrict the usage of a attribute we use USAGE ATTRIBUTE which governing how attributes work inception
    */
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]

    internal class DepartmentAttribute : ValidationAttribute
    {
        private readonly string[] _allowedDepartments;

        public DepartmentAttribute(string[] allowedDepartments)
        {
            _allowedDepartments = allowedDepartments;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            //CHECK IF THE VALUE IS NULL OR EMPTY
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Department is required.");
            }

            //check if the provided department is in the list of allowed departments
            var departmentValue = value.ToString();

            //look at each department name and see if it matches the name recieved as input 
            if (Array.Exists(_allowedDepartments, dept => dept.Equals(departmentValue, StringComparison.OrdinalIgnoreCase)))
            {
                return ValidationResult.Success;
            }

            //Return error if the department is not valid
            return new ValidationResult("Ïnvalid department");
        }
    }
}
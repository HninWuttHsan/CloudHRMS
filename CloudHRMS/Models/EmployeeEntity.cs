using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.Models
{
    [Table("Employee")] // Model Attribute in mVC
    public class EmployeeEntity : BaseEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        [MaxLength(1)]// Model Attribute in mVC
        public char Gender { get; set; }
        public required DateTime DOB { get; set; }
        public required DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public required string Address { get; set; }
        [Precision(18, 2)]// Model Attribute in MVC
        public required decimal BasicSalary { get; set; }
        public required string Phone { get; set; }


    }
}

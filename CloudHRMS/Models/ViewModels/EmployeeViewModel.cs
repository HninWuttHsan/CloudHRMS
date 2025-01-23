namespace CloudHRMS.Models.ViewModels
{
    public class EmployeeViewModel
    {
        // delete annotation
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public char Gender { get; set; }
        public required DateTime DOB { get; set; }
        public required DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public required string Address { get; set; }
        public required decimal BasicSalary { get; set; }
        public required string Phone { get; set; }
    }
}

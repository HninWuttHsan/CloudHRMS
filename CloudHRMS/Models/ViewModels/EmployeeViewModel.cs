namespace CloudHRMS.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public required string Id { get; set; }// for delete and update purpose
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

        // foreign key in here
        public required string DepartmentId { get; set; } // for update data/ record in DB

        public string DepartmentInfo { get; set; } // for show the values / record 
        public required string PositionId { get; set; } // for show the values

        public string PositionInfo { get; set; }



    }
}

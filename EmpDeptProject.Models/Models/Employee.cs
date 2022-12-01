using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpDeptProject.Models.Models
{
    public class Employee

    {
        [Key]

        [Display(Name = "Employee Id")]
        public int EmpId { get; set; }

        [StringLength(20,ErrorMessage ="Length should be 20 Character only")]
        [Required]
        [RegularExpression("^((?!City)[a-zA-Z '])+$", ErrorMessage = "Only Enter the Characters")]

        [Display(Name = "Employee Name")]
        public string?  EmpName { get; set; }

        [Required]
        public int Salary { get; set; }


        [Display(Name = "Department Name")]
        public  int DeptId { get; set; }
        [ForeignKey("DeptId")]

        public Department? Departments { get; set; }

    }
}

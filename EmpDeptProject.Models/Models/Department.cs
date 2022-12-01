using System.ComponentModel.DataAnnotations;

namespace EmpDeptProject.Models.Models
{
    public class Department
    {
        [Key]

        [Display(Name = "Department Id")]
        public int DeptId { get; set; }

        [StringLength(20)]
        [Required]
        [RegularExpression("^((?!City)[a-zA-Z '])+$", ErrorMessage = "Only Enter the Characters")]

        [Display(Name = "Department Name")]
        public string? DeptName { get; set; }

       
    }
}

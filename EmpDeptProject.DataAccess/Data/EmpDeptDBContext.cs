using EmpDeptProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpDeptProject.DataAccess.Data
{
    public class EmpDeptDBContext:DbContext
    {
        public EmpDeptDBContext(DbContextOptions<EmpDeptDBContext>options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

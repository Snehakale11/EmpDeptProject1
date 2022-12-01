using EmpDeptProject.Models.Models;
using EmpDeptProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpDeptProject.DataAccess.Data;

namespace EmpDeptProject.DataAccess.Repository
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        private readonly EmpDeptDBContext _empdb;
        public EmployeeRepository(EmpDeptDBContext empdb):base (empdb)
        {
            _empdb = empdb;
        }

        //public void save()
        //{
        //    _empdb.SaveChanges();
        //}

        public void Update(Employee obj)
        {
            _empdb.Update(obj);
        }


    }
}

using EmpDeptProject.DataAccess.Data;
using EmpDeptProject.DataAccess.Repository.IRepository;
using EmpDeptProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDeptProject.DataAccess.Repository
{
    public class DepartmentRepository:Repository<Department>, IRepository.IDepartmentRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmpDeptDBContext _ddb;
            public DepartmentRepository(EmpDeptDBContext ddb) : base(ddb)
            {
                _ddb = ddb;
            }

            public void Update(Department obj)
            {
                _ddb.Update(obj);
            }

      
    }
}


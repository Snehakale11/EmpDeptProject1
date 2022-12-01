using EmpDeptProject.DataAccess.Data;
using EmpDeptProject.DataAccess.Repository;
using EmpDeptProject.DataAccess.Repository.IRepository;
using EmpDeptProject.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmpDeptProject1.Controllers
{
   // private readonly EmpDeptDBContext _edb;

    public class EmployeesController : Controller
    {
        //private readonly EmpDeptDBContext _edb;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmpDeptDBContext _db;

        public EmployeesController(IUnitOfWork unitOfWork,EmpDeptDBContext db)
        {
          _unitOfWork = unitOfWork;
          _db = db;
        }

       
        public IActionResult Index()
        {
            var allEmployees = _db.Employees.Include(c => c.Departments);
            var allCategories = _unitOfWork.Employee.GetAll();
            
             
            return View(allEmployees);

        }
        public IActionResult Details(int id)
        {
            var category = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmpId == id);
            
            return View(category);
        }
        public IActionResult Create()
        {
            ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee catobj)
        {
            //if(catobj.CategoryName==catobj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "Display order cannot match the Category name");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Add(catobj);
                _unitOfWork.Save();
                ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
                TempData["Success"] = " Employee added suceessfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
                return View(catobj);
            }


        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var categoryFirstOrDefault = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmpId == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            ViewBag.DeptID = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
            if (categoryFirstOrDefault == null)
            {
                return NotFound();
            }
            return View(categoryFirstOrDefault);

        }
        //Edit-post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult Edit(Employee catobj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Update(catobj);

                ViewBag.DeptID = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
                _unitOfWork.Save();

                TempData["Success"] = "Employee updated suceessfully";
                return RedirectToAction(nameof(Index));

            }
            ViewBag.DeptID = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
            return View(catobj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmpId == id);
            // var categoryFirstOrDefault = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Employee.GetFirstOrDefault(c => c.EmpId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();

            TempData["Success"] = "Employee deleted suceessfully";
            return RedirectToAction(nameof(Index));
        }
    }

}


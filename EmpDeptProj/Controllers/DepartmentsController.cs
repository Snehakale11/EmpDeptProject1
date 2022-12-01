using EmpDeptProject.DataAccess.Data;
using EmpDeptProject.DataAccess.Repository.IRepository;
using EmpDeptProject.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpDeptProject.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
       
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var allCategories = _unitOfWork.Department.GetAll();

            return View(allCategories);

        }
        public IActionResult Details(int id)
        {
            var category = _unitOfWork.Department.GetFirstOrDefault(c => c.DeptId == id);

            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department catobj)
        {
          
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Add(catobj);
                _unitOfWork.Save();
                TempData["Success"] = "Department added suceessfully";
                return RedirectToAction(nameof(Index));
            }

            return View(catobj);


        }
        public IActionResult Edit(int? deptId)
        {
            if (deptId == null || deptId == 0)
            {
                return NotFound();
            }
            var categoryFirstOrDefault = _unitOfWork.Department.GetFirstOrDefault(c =>
            c.DeptId == deptId);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);

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
        public IActionResult Edit(Department catobj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(catobj);
                _unitOfWork.Save();

                TempData["Success"] = "Department updated suceessfully";
                return RedirectToAction(nameof(Index));
            }

            return View(catobj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Department.GetFirstOrDefault(c => c.DeptId == id);
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
            var obj = _unitOfWork.Department.GetFirstOrDefault(c => c.DeptId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();

            TempData["Success"] = "Department deleted suceessfully";
            return RedirectToAction(nameof(Index));
        }
    }
}


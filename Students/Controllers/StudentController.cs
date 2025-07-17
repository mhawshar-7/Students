using CoreData.Entities;
using CoreData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var data = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student model)
        {
            Student student;
            if (model.Id == 0) 
            {
                student = new Student(model.Name, model.Age, model.Major, model.GPA, model.ContactInfo);
                _unitOfWork.Repository<Student>().Create(student);
            }
            else
            {
                student = await _unitOfWork.Repository<Student>().GetByIdAsync(model.Id);
                student.Name = model.Name;
                student.Age = model.Age;
                student.Major = model.Major;
                student.GPA = model.GPA;
                student.ContactInfo = model.ContactInfo;
                _unitOfWork.Repository<Student>().Update(student);
            }
            await _unitOfWork.Complete();
            return RedirectToAction("StudentList", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> StudentList()
        {
            //var list = await _studentRepository.GetStudentsAsync();
            var list = await _unitOfWork.Repository<Student>().ListAllAsync();
            return View(list);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveStudent(int id)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
            _unitOfWork.Repository<Student>().Delete(student);

            await _unitOfWork.Complete();
            return RedirectToAction("StudentList", "Student");
        }
    }
}

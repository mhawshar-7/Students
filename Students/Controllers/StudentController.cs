using CoreData.Entities;
using CoreData.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Students.Models;

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
            StudentModel? model = null;
            if (data is not null)
            {
                model = new StudentModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Age = data.Age,
                    Major = data.Major,
                    GPA = data.GPA,
                    ContactInfo = data.ContactInfo
                };
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentModel model)
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
            var model = list.Select(s => new StudentModel
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Major = s.Major,
                GPA = s.GPA,
                ContactInfo = s.ContactInfo,
                ModifiedDate = s.ModifiedDate.ToString("dd/MM/yyyy")
            }).ToList();
            return View(model);
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

using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointment.Controllers
{
    public class DepartmantController : Controller
    {
        public IDepartmantService _depservice;
        public DepartmantController(IDepartmantService depservice)
        {
            _depservice = depservice;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Departmant model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _depservice.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }

        }
    }
}

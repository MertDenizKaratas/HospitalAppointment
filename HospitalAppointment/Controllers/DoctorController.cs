using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAppointment.Controllers
{
    public class DoctorController : Controller
    {
        public readonly IDoctorService _docservice;
        public readonly ITimeService _timeService;
        public readonly IFileService _fileservice;
        public readonly IDepartmantService _departmantService;
        public DoctorController(IDoctorService docservice, ITimeService timeservice, IFileService fileservice, IDepartmantService departmantservice)
        {
            _docservice = docservice;
            _timeService = timeservice;
            _fileservice = fileservice;
            _departmantService= departmantservice;
        }
        public IActionResult Add()
        {
            var model = new Doctor();
            model.TimeList = _timeService.List().Select(a => new SelectListItem { Text=a.AvailableTime, Value=a.Id.ToString()});
            model.DepartmantList = _departmantService.List().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Add(Doctor model)
        {
            model.TimeList = _timeService.List().Select(a => new SelectListItem { Text = a.AvailableTime, Value = a.Id.ToString() });
            model.DepartmantList = _departmantService.List().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileservice.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.MovieImage = imageName;
            }
            var result = _docservice.Add(model);
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
        public IActionResult AddMovieWithSelectOneGenre(int id)
        {
            var model = _docservice.GetById(id);
            model.SelectedTime = _timeService.SelectedList(id).Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }
        [HttpPost]
        public IActionResult AddMovieWithSelectOneGenre(Movie model)
        {


            ModelState.Remove("Genres");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _movieService.SingleMovieGenreAdd(model);
            if (result)
            {
                var user = _userManager.GetUserId(User);
                var patient = new Patient { UserId = user, MovieId = model.Id };
                var resultPatient = _movieService.PatientWithMovieAdd(patient);
                if (!resultPatient)
                {
                    TempData["msg"] = "Error on server side";
                    return View(model);
                }
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

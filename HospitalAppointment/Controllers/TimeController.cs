using HospitalAppointment.Models.Domain;
using HospitalAppointment.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalAppointment.Controllers
{
    public class TimeController : Controller
    {
        public ITimeService _timeservice;
        public TimeController(ITimeService timeservice)
        {
            _timeservice = timeservice;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Time time)
        {
            var dt = new DateTime(2023, 01, 01, 9, 0, 0);
            for (int i = 0; i < 9; i++)
            {
                var model = new Time()
                {
                    
                    AvailableTime = dt.ToString(),
                    TimeType = "1 Hours Gap"
              
                };
           
                _timeservice.Add(model);
                dt = dt.AddMinutes(60);
            };
            return RedirectToAction("Index");
           
            
            //if (!ModelState.IsValid)
            //    return View(model);
            //var result = _timeservice.Add(model);
            //if (result)
            //{
            //    TempData["msg"] = "Added Successfully";
            //    return RedirectToAction(nameof(Add));
            //}
            //else
            //{
            //    TempData["msg"] = "Error on server side";
            //    return View(model);
            //}
        }
    }
}

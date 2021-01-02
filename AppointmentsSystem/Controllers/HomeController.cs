using AppointmentsSystem.Models;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppointmentOperation _appointmentOperation;

        public HomeController(ILogger<HomeController> logger, IAppointmentOperation appointmentOperation)
        {
            _logger = logger;
            _appointmentOperation = appointmentOperation;
        }

        public IActionResult Index()
        {
            AppointmentListVM model = new AppointmentListVM()
            {
                Appointments = _appointmentOperation.GetAll()
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new AppointmentCUVM { };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AppointmentCUVM model)
        {
            if (!ModelState.IsValid)
            {
                return View( new AppointmentCUVM() );
            }

            _appointmentOperation.CreateAppointment(model.Appointment);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
           if (id == null)
            {
                return NotFound();
            }

            // casting to int from int? , to avoid adding more code
            var model = _appointmentOperation.GetAppointment((int)id);

            if(model == null)
            {
                return NotFound();
            }
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

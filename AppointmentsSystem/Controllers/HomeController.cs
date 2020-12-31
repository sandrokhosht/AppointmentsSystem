using AppointmentsSystem.Models;
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

        private readonly IUOW _uow;

        public HomeController(ILogger<HomeController> logger, IUOW uOW)
        {
            _logger = logger;
            _uow = uOW;
        }

        public IActionResult Index()
        {
            var ap = new Appointment()
            {
                FirstName = "Sandro",
                LastName = "Khoshtaria",
                Description = "Headache",
                Gender = 'M',
                PhoneNumber = "591600149",
            };
            _uow.Appointment.Create(ap);
            _uow.Commit();
            return View();
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
